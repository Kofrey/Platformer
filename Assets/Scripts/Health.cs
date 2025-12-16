using UnityEngine;
using System;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    
    private int _currentHealth;

    public event Action HitTaken;
    public event Action DeathPerforming;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;

        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        
        HitTaken?.Invoke();

        if(_currentHealth <= 0)
        {
            DeathPerforming?.Invoke();
        }
    }
}
