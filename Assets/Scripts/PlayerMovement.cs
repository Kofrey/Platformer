using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [Header("Movement")]
    [SerializeField] private Mover _mover;

    [Header("Jumping")]
    [SerializeField] private int _maxJumps = 2;

    [Header("GroundCheck")]
    [SerializeField] private GroundDetector _groundDetector;

    [Header("Gravity")]
    [SerializeField] private float _baseGravity = 2f;
    [SerializeField] private float _maxFallSpeed = 18f;
    [SerializeField] private float _fallSpeedMultiplier = 2f;

    bool _isFacingRight = true;
    private float _horizontalMovement;
    private int _jumpsRemaining;

    private int _magnitude;
    private string _magnitudeName = "magnitude";
    private int _yVelocity;
    private string _yVelocityName = "yVelocity";
    private int _jump;
    private string _jumpName = "jump";
    
    private void Awake()
    {
        _magnitude = Animator.StringToHash(_magnitudeName);
        _yVelocity = Animator.StringToHash(_yVelocityName);
        _jump = Animator.StringToHash(_jumpName);
    }

    private void Update()
    {
        _mover.Move(_horizontalMovement);
       
        Gravity();
        Flip();

        _animator.SetFloat(_magnitude, _rigidbody.linearVelocity.magnitude);
        _animator.SetFloat(_yVelocity, _rigidbody.linearVelocityY);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (_groundDetector.IsGround)
            _jumpsRemaining = _maxJumps;

        if(_jumpsRemaining > 0)
        {
            if (context.performed)
            {
                _mover.Jump();
                _jumpsRemaining--;
                _animator.SetTrigger(_jump);
            }
        }
    }

    private void Flip()
    {
        if(_isFacingRight && _horizontalMovement < 0 || !_isFacingRight && _horizontalMovement > 0)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Gravity()
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
