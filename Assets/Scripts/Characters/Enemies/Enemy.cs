using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : ObjectSpawned
{
    [SerializeField] private PatrolState _patrol;
    [SerializeField] private ChaseState _chase;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private float _distanceToStartAttack;
 
    private IState _currentState;
    private bool _isAlert = false;
    private bool _isRaycasting = false;
    private float _alertCheckTime = 1.4f;
    private float _distanceToCheckAlert = 7f;
    private Coroutine _raycasting;
    private float _raycastingTime = 0.9f;

    private void Awake()
    {
        _health.DeathPerforming += OnDeathPerforming;
        _currentState = _patrol;
        Player _player = FindAnyObjectByType<Player>();
        _playerTransform = _player.transform;
        StartCoroutine(AlertValidation(_playerTransform, _distanceToCheckAlert, _alertCheckTime));
    }

    private void SetState(IState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public bool IsCloseEnough(Vector3 distance, float distanceToCheck)
    {
        return distance.sqrMagnitude < distanceToCheck * distanceToCheck;
    }

    private IEnumerator AlertValidation(Transform alertSource, float distance, float checkTimer)
    {
        while(enabled)
        {
            _isAlert = IsCloseEnough(alertSource.position - transform.position, distance);
            
            if(_isAlert == true && _isRaycasting == false)
            {
                _raycasting = StartCoroutine(LookForDanger(_raycastingTime));
                _isRaycasting = true;
                StartCoroutine(DoAttack(alertSource, _distanceToStartAttack));
            }
            else if (_isAlert == false && _isRaycasting == true)
            {
                StopCoroutine(_raycasting);
                SetState(_patrol);
                _isRaycasting = false;
            }

            yield return new WaitForSeconds(checkTimer);
        }    
    }

    private IEnumerator LookForDanger(float time)
    {
        while(enabled)
        {
            Vector3 direction = _playerTransform.position - transform.position;
            RaycastHit2D alert = Physics2D.Raycast(transform.position + direction.normalized, direction, _distanceToCheckAlert * 3); 

            if (alert != null && alert.transform.TryGetComponent<Player>(out Player player))
            {
                SetState(_chase);
                _chase.SetTarget(player.transform);
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator DoAttack(Transform enemyTransform, float distance)
    {
        while(_isAlert)
        {
            if(IsCloseEnough(enemyTransform.position - transform.position, distance))
                _attacker.Attack();

            yield return null;
        }
    }

    private void OnDeathPerforming()
    {
        InvokeDestroying();
    }
}
