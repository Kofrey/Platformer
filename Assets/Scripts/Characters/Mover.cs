using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Move(float direction)
    {
        _rigidbody.linearVelocityX = _speedX * direction * Time.fixedDeltaTime;
    }
}
