using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private Patrol _patrol;
 
    private IState _currentState;

    public int Damage => _damage;

    private void Awake()
    {
        _currentState = _patrol;
    }

    public void SetState(IState state)
    {
        _currentState = state;
    }
}
