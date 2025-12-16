using System;
using UnityEngine;

public class Coin : ObjectSpawned
{
    [SerializeField] private int _worth = 1;

    public int Worth => _worth;
}
