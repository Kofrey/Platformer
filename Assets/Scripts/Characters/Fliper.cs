using UnityEngine;

public class Fliper : MonoBehaviour
{
    private bool _isFacingRight = true;
    private Vector3 _facingRightAngle;
    private Vector3 _facingLeftAngle;

    private void Start()
    {
        _facingRightAngle = transform.eulerAngles;
        _facingRightAngle.y = 0;
        _facingLeftAngle = transform.eulerAngles;
        _facingLeftAngle.y = 180;
    }

    public void Flip(float _moveX)
    {
        if(_isFacingRight && _moveX < 0)
        {
            _isFacingRight = !_isFacingRight;
            transform.rotation = Quaternion.Euler(_facingLeftAngle);
        }

        if(!_isFacingRight && _moveX > 0)
        {
            _isFacingRight = !_isFacingRight;
            transform.rotation = Quaternion.Euler(_facingRightAngle);
        }
    }
}
