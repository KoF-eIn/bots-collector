using System;

public class ResourceStorage
{
    public int Amount { get; private set; }

    public event Action<int> Changed;

    public void Add(int value)
    {
        Amount += value;
        Changed?.Invoke(Amount);
    }
}