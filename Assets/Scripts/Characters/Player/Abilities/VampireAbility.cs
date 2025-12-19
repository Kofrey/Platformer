using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _tickDamage = 1;
    [SerializeField] private float _tickTime = 1f;
    [SerializeField] private Health _ownerHealth;

    private Collider2D[] _colliders;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        StartCoroutine(Execute(_tickTime));
    }

    private void Start()
    {
        transform.localScale *= _radius;
    }

    private void Tick()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        _colliders = Physics2D.OverlapCircleAll(position, _radius, _layerMask);

        if(_colliders.Length == 0)
            return;

        Collider2D target = GetNearest(_colliders);

        if(target.TryGetComponent<Health>(out Health health))
        {
            int damage = health.TakeDamage(_tickDamage);
            _ownerHealth.Heal(damage);
        }
    }

    private IEnumerator Execute(float time)
    {
        while(enabled)
        {
            Tick();
            yield return new WaitForSeconds(time);
        }
    }

    private Collider2D GetNearest(Collider2D[] colliders)
    {
        int index = 0;
        Vector3 minDistance = transform.position - colliders[0].transform.position;

        for(int i = 1; i < colliders.Length; i++)
        {
            Vector3 nextDistance = transform.position - colliders[i].transform.position;

            if(nextDistance.sqrMagnitude < minDistance.sqrMagnitude)
            {
                index = i;
                minDistance = nextDistance;
            }
        }

        return colliders[index];
    }
}
