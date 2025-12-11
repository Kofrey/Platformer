using UnityEngine;
using UnityEngine.InputSystem;

public class Jumper : MonoBehaviour
{
    [SerializeField] private AnimatorAgent _agent;
    [SerializeField] private Mover _mover;
    [SerializeField] private int _maxJumps = 2;
    [SerializeField] private GroundDetector _groundDetector;

    private int _jumpsRemaining;

    public void Jump(InputAction.CallbackContext context)
    {
        if (_groundDetector.IsGround())
            _jumpsRemaining = _maxJumps;

        if(_jumpsRemaining > 0)
        {
            if (context.performed)
            {
                _mover.Jump();
                _jumpsRemaining--;
                _agent.SetTrigger(_agent.Jump);
            }
        }
    }
}
