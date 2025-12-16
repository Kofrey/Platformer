using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private GravityScaler _gravityScaler;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Attacker _attacker;

    private float _horizontalMovement;

    private void Update()
    {
        _mover.Move(_horizontalMovement);
        _fliper.Flip(_horizontalMovement);
        _gravityScaler.Gravity();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            _jumper.Jump();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        _attacker.Attack();
    }
}
