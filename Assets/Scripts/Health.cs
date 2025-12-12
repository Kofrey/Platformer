using UnityEngine;
using System;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] SpriteRenderer _spriteRenderer;

    private int _currentHealth;

    public event Action HitTaken;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy resource))
            TakeDamage(resource.Damage);
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        
        HitTaken?.Invoke();
        //StartCoroutine(FlashRed());

        if(_currentHealth <= 0)
        {

        }
    }

    private IEnumerator FlashRed()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.color = Color.white;
    }
}
