using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    [SerializeField] private AnimatorAgent _agent;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {
        _agent.SetFloat(_agent.YVelocity, _rigidbody.linearVelocityY);
        _agent.SetFloat(_agent.Magnitude, _rigidbody.linearVelocity.magnitude);
    }
}
