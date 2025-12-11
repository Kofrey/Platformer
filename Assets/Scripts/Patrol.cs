using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
  
    private float _rayLength = 0.7f;
    private float _direction = 1.0f;
    private float _checkInterval = 0.4f;
    private float _checkTimer = 0f;

    private void CheckWay()
    {
        RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(_direction, 0f), _rayLength, _groundLayer);
        RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(_direction * _rayLength, 0, 0), Vector2.down, _rayLength, _groundLayer);     
    
        if (!gapAhead || groundInFront)
            _direction *= -1;
    }

    public float PatrolMove()
    {
        if (_checkTimer > _checkInterval)
        {
            CheckWay();
            _checkTimer -= _checkInterval;
        }

        _checkTimer += Time.deltaTime;
        return _direction;
    }
}
