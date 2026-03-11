using UnityEngine;
using System;

public class Resource : MonoBehaviour
{
    public Vector3 Position => transform.position;

    public event Action<Resource> Collected;

    public void Pick()
    {
        Collected?.Invoke(this);
        Destroy(gameObject);
    }
}