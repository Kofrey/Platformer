using System;
using UnityEngine;

public class Spawned : MonoBehaviour
{
    public event Action<Spawned> Destroying;

    public void InvokeDestroying()
    {
        Destroying?.Invoke(this);
    }
} 
