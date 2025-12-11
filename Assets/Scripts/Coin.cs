using System;
using UnityEngine;


public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int _worth = 1;

    public static event Action<int> OnCoinCollect;

    public void Collect()
    {
        OnCoinCollect.Invoke(_worth);
        Destroy(gameObject);
    }
}
