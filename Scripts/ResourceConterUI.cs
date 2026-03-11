using TMPro;
using UnityEngine;

public class ResourceCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private ResourceStorage _storage;

    public void Construct(ResourceStorage storage)
    {
        _storage = storage;

        _storage.Changed += UpdateView;

        UpdateView(_storage.Amount);
    }

    private void UpdateView(int value)
    {
        _text.text = $"Resources: {value}";
    }
}