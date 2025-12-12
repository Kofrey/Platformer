using UnityEngine;

public class AnimatorAgent : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _magnitude;
    private string _magnitudeName = "magnitude";
    private int _yVelocity;
    private string _yVelocityName = "yVelocity";
    private int _jump;
    private string _jumpName = "jump";
    
    public int Magnitude => _magnitude;
    public int YVelocity => _yVelocity;
    public int Jump => _jump;

    private void Awake()
    {
        _magnitude = Animator.StringToHash(_magnitudeName);
        _yVelocity = Animator.StringToHash(_yVelocityName);
        _jump = Animator.StringToHash(_jumpName);
    }

    public void SetFloat(int id, float value)
    {
        _animator.SetFloat(id, value);
    }

    public void SetTrigger(int id)
    {
        _animator.SetTrigger(id);
    }
}
