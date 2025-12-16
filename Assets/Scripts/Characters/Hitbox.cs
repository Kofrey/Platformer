using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _exitTime = 0.4f;

    private void OnEnable()
    {
        StartCoroutine(DisableCount());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out Health resource))
            resource.TakeDamage(_damage);
    }

    private IEnumerator DisableCount()
    {
        yield return new WaitForSeconds(_exitTime);
        gameObject.SetActive(false);
    }
}
