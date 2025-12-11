using UnityEngine;

public class Fliper : MonoBehaviour
{
    private bool _isFacingRight = true;

    public void Flip(float _moveX)
    {
        if(_isFacingRight && _moveX < 0 || !_isFacingRight && _moveX > 0)
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(0, 180, 0);
        }
    }
}
