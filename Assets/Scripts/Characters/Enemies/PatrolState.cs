using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrolState : MonoBehaviour, IState
{
    [SerializeField] private Fliper _fliper;
    [SerializeField] private Mover _mover;
    [SerializeField] private LayerMask _layerMask;

    private float _rayLength = 0.7f;
    private float _direction = 1.0f;
    private float _checkInterval = 0.4f;
    private float _checkTimer = 0f;

    public void Update()
    {
        float direction = PatrolMove(_layerMask);
        _mover.Move(direction);
        _fliper.Flip(direction);
    }

    public void Exit()
    {
        this.enabled = false;
    }

    public void Enter()
    {
        this.enabled = true;
    }

    private float PatrolMove(LayerMask groundLayer)
    {
        if (_checkTimer > _checkInterval)
        {
            if(IsFartherWayFeasible(groundLayer) == false)
                _direction *= -1;

            _checkTimer -= _checkInterval;
        }

        _checkTimer += Time.deltaTime;
        return _direction;
    }

    private bool IsFartherWayFeasible(LayerMask groundLayer)
    {
        RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(_direction, 0f), _rayLength, groundLayer);
        RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(_direction * _rayLength, 0, 0), Vector2.down, _rayLength, groundLayer);     
    
        if (!gapAhead || groundInFront)
            return false;

        return true;
    }
}
