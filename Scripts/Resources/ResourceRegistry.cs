using System.Collections.Generic;

public class ResourceRegistry
{
    private readonly List<Resource> _resources = new();

    public IReadOnlyList<Resource> Resources => _resources;

    public void Register(Resource resource)
    {
        if (_resources.Contains(resource))
            return;

        _resources.Add(resource);
        resource.Collected += Unregister;
    }

    private void Unregister(Resource resource)
    {
        resource.Collected -= Unregister;
        _resources.Remove(resource);
    }
}