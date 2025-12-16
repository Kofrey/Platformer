using UnityEngine;
using System;

public class HealItem : ObjectSpawned
{
    [SerializeField] private int _amount = 1;

    public int Amount => _amount;
}
