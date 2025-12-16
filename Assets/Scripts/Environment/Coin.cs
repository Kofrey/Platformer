using System;
using UnityEngine;

public class Coin : Spawned
{
    [SerializeField] private int _worth = 1;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<Collector>(out Collector resource))
        {
            resource.OnCoinCollecting(_worth);
            InvokeDestroying();
        }
    }
}
