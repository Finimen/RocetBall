using UnityEngine;

public class AbilitySaver : MonoBehaviour
{
    public void Save(int id)
    {
        PlayerPrefs.SetInt("AbilityId", id);
    }
}
