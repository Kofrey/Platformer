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

    private void OnEnable()
    {
        _health.HitTaken += OnHitTaken;
    }

    private void OnDisable()
    {
        _health.HitTaken -= OnHitTaken;
    }

    private void Update()
    {
        _agent.SetFloat(_agent.YVelocity, _rigidbody.linearVelocityY);
        _agent.SetFloat(_agent.Magnitude, Mathf.Abs(_rigidbody.linearVelocityX));
    }

    private void OnHitTaken()
    {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(_flashTime);
        _spriteRenderer.color = Color.white;
    }
}
