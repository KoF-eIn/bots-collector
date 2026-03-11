using UnityEngine;
using System;
using System.Collections;

public class Unit : MonoBehaviour
{
    private UnitCollector _collector;

    public bool Busy { get; private set; }

    public event Action<Unit, Resource> ResourceDelivered;

    public void Construct(UnitMovement movement)
    {
        _collector = new UnitCollector(movement);
    }

    public void Collect(Resource resource, Vector3 basePosition)
    {
        StartCoroutine(Process(resource, basePosition));
    }

    private IEnumerator Process(Resource resource, Vector3 basePosition)
    {
        Busy = true;

        yield return _collector.Collect(resource, basePosition);

        ResourceDelivered?.Invoke(this, resource);

        Busy = false;
    }
}