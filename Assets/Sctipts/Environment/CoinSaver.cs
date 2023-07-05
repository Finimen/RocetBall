using UnityEngine;

public class StaticObjectSaver : MonoBehaviour
{
    [SerializeField] private StatickObjectList staticList;

    [SerializeField] public bool ActionDone
    {
        get
        {
            return staticList.GetSavedInfo(this);
        }
    }

    public void DoneAction()
    {
        staticList.SaveCompleteInfo(this);
    }
}