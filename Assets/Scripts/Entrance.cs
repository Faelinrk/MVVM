using System;
using UnityEngine;

public sealed class Entrance : MonoBehaviour
{
    public event Action OnStart;
    public event Action OnUpdate;
    private void Start()
    {
        OnStart?.Invoke();
    }
    private void Update()
    {
        OnUpdate?.Invoke();
    }
}
