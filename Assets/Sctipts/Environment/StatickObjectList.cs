using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Saves/StaticObjects")]
public class StatickObjectList : ScriptableObject
{
    [SerializeField] private StaticObjectSaver[] staticObjects;

    public void SaveCompleteInfo(StaticObjectSaver staticObject)
    {
        SaveSystem.SaveBool("StatickObject" + Array.IndexOf(staticObjects, staticObject), true);
    }

    public bool GetSavedInfo(StaticObjectSaver staticObject)
    {
        return SaveSystem.LoadBool("StatickObject" + Array.IndexOf(staticObjects, staticObject));
    }
}