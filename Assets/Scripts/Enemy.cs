using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _isPatrolling = true;
    
    private float _rayLength = 0.7f;
    private float _direction = 1.0f;
    private float _checkInterval = 0.4f;
 
    private void Awake()
    {
        StartCoroutine(Patrol());
    }

    private void Update()
    {
        if (_groundDetector.IsGround && _isPatrolling)
        {
            _mover.Move(_direction);
        }
    }

    private bool CheckWay()
    {
        RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(_direction, 0f), _rayLength, _groundLayer);
        RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(_direction * _rayLength, 0, 0), Vector2.down, _rayLength, _groundLayer);     
    
        if (!gapAhead || groundInFront)
            return false;
        else 
            return true;
    }

    private IEnumerator Patrol()
    {
        while(_isPatrolling)
        {
            if(CheckWay() == false)
                _direction *= -1;

            yield return new WaitForSeconds(_checkInterval);
        }
    }
}
