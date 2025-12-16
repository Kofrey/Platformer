using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class Chase : MonoBehaviour
{
    [SerializeField] private Fliper _fliper;
    [SerializeField] private Mover _mover;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _target;

    private float _rayLength = 0.5f;
    private float _direction = 1.0f;
    private float _checkInterval = 0.4f;
    private float _checkTimer = 0f;

    public void SetTarget(Transform targetTransform)
    {
        _target = targetTransform;
    }

    private float GetDirection()
    {
        if (_target.position.x > transform.position.x)
            return 1f;
        else
            return -1f;
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

public partial class Chase : IState
{
    public void Update()
    {
        _direction = GetDirection();

        if(IsFartherWayFeasible(_groundMask) == true)
            _mover.Move(_direction);
        
        _fliper.Flip(_direction);
    }

    public void Exit()
    {
        this.enabled = false;
    }

    public void Enter()
    {
        this.enabled = true;
    }
}