using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource _resourcePrefab;

    [SerializeField] private Vector2 _size;

    [SerializeField] private float _spawnDelay = 3f;

    private ResourceRegistry _registry;

    public void Construct(ResourceRegistry registry)
    {
        _registry = registry;

        InvokeRepeating(nameof(Spawn), 1f, _spawnDelay);
    }

    private void Spawn()
    {
        Vector3 position = new(
            Random.Range(-_size.x, _size.x),
            0,
            Random.Range(-_size.y, _size.y));

        Resource resource = Instantiate(_resourcePrefab, position, Quaternion.identity);

        _registry.Register(resource);
    }
}