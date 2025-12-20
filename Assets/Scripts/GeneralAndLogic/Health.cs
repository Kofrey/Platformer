using UnityEngine;
using System;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 3;
    [SerializeField] private int _current;

    public int Max => _max;
    public int Current => _current;

    public event Action Dead;
    public event Action<int> AmountChanged;

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

        AmountChanged?.Invoke(_current);
    }

    public int TakeDamage(int damage)
    {
        int damageTaken = damage;
        _current -= damage;
        
        AmountChanged?.Invoke(_current);

        if(_current <= 0)
        {
            damageTaken = damage + _current;
            _current = 0;
            Dead?.Invoke();
        }

        return damageTaken;
    }
}
