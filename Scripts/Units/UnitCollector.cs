using UnityEngine;
using System.Collections;

public class UnitCollector
{
    private readonly UnitMovement _movement;
    private readonly Transform _transform;

    public UnitCollector(UnitMovement movement)
    {
        _movement = movement;
        _transform = movement.transform;
    }

    public IEnumerator Collect(Resource resource, Vector3 basePosition)
    {
        Vector3 resourcePosition = resource.Position;

        yield return _movement.MoveTo(resourcePosition);

        resource.Pick();

        yield return _movement.MoveTo(basePosition);
    }
}