using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AnimatorAgent _agent;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Mover _mover;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private GravityScaler _gravityScaler;

    private float _horizontalMovement;

    private void Update()
    {
        _mover.Move(_horizontalMovement);
        _fliper.Flip(_horizontalMovement);
        _gravityScaler.Gravity();

        _agent.SetFloat(_agent.YVelocity, _rigidbody.linearVelocityY);
        _agent.SetFloat(_agent.Magnitude, _rigidbody.linearVelocity.magnitude);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontalMovement = context.ReadValue<Vector2>().x;
    }
}
