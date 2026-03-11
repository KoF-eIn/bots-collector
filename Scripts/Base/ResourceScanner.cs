using System.Collections.Generic;
using UnityEngine;

public class ResourceScanner
{
    private readonly ResourceRegistry _registry;

    public ResourceScanner(ResourceRegistry registry)
    {
        _registry = registry;
    }

    public Resource GetNearestResource(Vector3 position, HashSet<Resource> reserved)
    {
        Resource nearest = null;

        float distance = float.MaxValue;

        foreach (Resource resource in _registry.Resources)
        {
            if (reserved.Contains(resource))
                continue;

            float current = (resource.Position - position).sqrMagnitude;

            if (current < distance)
            {
                distance = current;
                nearest = resource;
            }
        }

        return nearest;
    }
}