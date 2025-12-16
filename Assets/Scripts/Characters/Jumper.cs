using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimatorAgent _agent;
    [SerializeField] private int _maxJumps = 2;
    [SerializeField] private GroundDetector _groundDetector;

    private int _jumpsRemaining;

    private void Start()
    {
        _jumpsRemaining = _maxJumps;
    }

    public void Jump()
    {
        if (_groundDetector.IsGround())
            _jumpsRemaining = _maxJumps;

        if(_jumpsRemaining > 0)
        {
            _rigidbody.linearVelocityY =  0;
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
            _jumpsRemaining--;
            _agent.SetTrigger(_agent.Jump);
        }
    }
}
