using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterRenderer : MonoBehaviour
{
    [SerializeField] private AnimatorAgent _agent;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Health _health;

    private float _flashTime = 0.15f;
    private int _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _health.Current;
        _health.AmountChanged += OnHealthAmountChaged;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= OnHealthAmountChaged;
    }

    private void Update()
    {
        _agent.SetFloat(_agent.YVelocity, _rigidbody.linearVelocityY);
        _agent.SetFloat(_agent.Magnitude, Mathf.Abs(_rigidbody.linearVelocityX));
    }

    private void OnHealthAmountChaged(int newHealth)
    {
        if(newHealth < _currentHealth)
            StartCoroutine(FlashColor(Color.red));
        else if(newHealth > _currentHealth)
            StartCoroutine(FlashColor(Color.green));

        _currentHealth = newHealth;
    }

    private IEnumerator FlashColor(Color color)
    {
        _spriteRenderer.color = color;
        yield return new WaitForSeconds(_flashTime);
        _spriteRenderer.color = Color.white;
    }
}
