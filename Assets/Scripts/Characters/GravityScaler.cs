using UnityEngine;

public class GravityScaler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _baseGravity = 2f;
    [SerializeField] private float _maxFallSpeed = 18f;
    [SerializeField] private float _fallSpeedMultiplier = 2f;

    public void Gravity()
    {
        if(_rigidbody.linearVelocityY < 0)
        {
            _rigidbody.gravityScale = _baseGravity * _fallSpeedMultiplier;
            _rigidbody.linearVelocityY = Mathf.Max(_rigidbody.linearVelocityY, -_maxFallSpeed);
        }
        else
        {
            _rigidbody.gravityScale = _baseGravity;
        }
    }
}
