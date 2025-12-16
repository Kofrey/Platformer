using System;
using UnityEngine;

public class ObjectSpawned : MonoBehaviour
{
    public event Action<ObjectSpawned> Destroying;

    public void InvokeDestroying()
    {
        Destroying?.Invoke(this);
    }

    public virtual void Collect()
    {
        InvokeDestroying();
    }
} 
