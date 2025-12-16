using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _exitTime = 0.6f;

    private void OnEnable()
    {
        Invoke("Exit", _exitTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out Health resource))
            resource.TakeDamage(_damage);
    }

    private void Exit()
    {
        gameObject.SetActive(false);
    }
}
