using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private Patrol _patrol;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private Mover _mover;
 
    public int Damage => _damage;

    private void Update()
    {
        float direction = _patrol.PatrolMove();
        _mover.Move(direction);
        _fliper.Flip(direction);
    }
}
