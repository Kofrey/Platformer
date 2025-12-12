using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int _worth = 1;

    public int Worth => _worth;

    public event Action<Coin> CoinCollecting;

    public void Collect()
    {
        CoinCollecting?.Invoke(this);
    }
}
