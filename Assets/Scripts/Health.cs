using UnityEngine;
using System;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 3;
    
    private int _current;

    public event Action HitTaken;
    public event Action DeathPerforming;

    private void Start()
    {
        _current = _max;
    }

    public void Heal(int amount)
    {
        _current += amount;

        if(_current > _max)
        {
            _current = _max;
        }
    }

    public void TakeDamage(int damage)
    {
        _current -= damage;
        
        HitTaken?.Invoke();

        if(_current <= 0)
        {
            DeathPerforming?.Invoke();
        }
    }
}
