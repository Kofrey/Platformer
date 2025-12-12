using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private AnimatorAgent _agent;
    [SerializeField] private Mover _mover;
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
            _mover.Jump();
            _jumpsRemaining--;
            _agent.SetTrigger(_agent.Jump);
        }
    }
}
