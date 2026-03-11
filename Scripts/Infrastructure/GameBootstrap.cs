using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private BaseController _base;
    [SerializeField] private ResourceSpawner _spawner;
    [SerializeField] private ResourceCounterUI _resourceUI;

    private void Awake()
    {
        ResourceRegistry registry = new();
        ResourceScanner scanner = new(registry);
        ResourceStorage storage = new();

        _base.Construct(scanner, storage);
        _spawner.Construct(registry);

        _resourceUI.Construct(storage);
    }
}