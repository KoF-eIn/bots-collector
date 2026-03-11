using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] private Unit[] _units;

    private ResourceScanner _scanner;
    private ResourceStorage _storage;

    private readonly HashSet<Resource> _reserved = new();

    public void Construct(ResourceScanner scanner, ResourceStorage storage)
    {
        _scanner = scanner;
        _storage = storage;

        foreach (Unit unit in _units)
            unit.ResourceDelivered += OnResourceDelivered;
    }

    private void Update()
    {
        foreach (Unit unit in _units)
        {
            if (unit.Busy)
                continue;

            Resource resource = _scanner.GetNearestResource(transform.position, _reserved);

            if (resource == null)
                return;

            _reserved.Add(resource);

            unit.Collect(resource, transform.position);
        }
    }

    private void OnResourceDelivered(Unit unit, Resource resource)
    {
        _reserved.Remove(resource);
        _storage.Add(1);
    }
}