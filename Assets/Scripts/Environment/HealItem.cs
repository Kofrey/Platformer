using UnityEngine;
using System;

public class HealItem : Spawned
{
    [SerializeField] private int _healAmount = 1;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<Collector>(out Collector resource))
        {
            resource.OnHealCollecting(_healAmount);
            InvokeDestroying();
        }
    }
}
