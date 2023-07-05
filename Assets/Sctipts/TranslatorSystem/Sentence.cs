using System;
using UnityEngine;

[Serializable]
public class Sentence
{
    [field: SerializeField] public Language Language { get; private set; }
    [field: SerializeField] public GameObject Text { get; private set;}
}