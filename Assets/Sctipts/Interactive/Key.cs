using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    public event Action OnPlayerEntered;

    public void OnPlayerEnter()
    {
        OnPlayerEntered.Invoke();

        Destroy(gameObject);
    }
}