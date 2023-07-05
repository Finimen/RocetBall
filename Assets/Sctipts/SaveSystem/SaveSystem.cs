using UnityEngine;

public static class SaveSystem
{
    public static void SaveBool(string name, bool data)
    {
        PlayerPrefs.SetInt(name, data? 1 : 0);
    }

    public static void SaveInt(string name, int data)
    {
        PlayerPrefs.SetInt(name, data);
    }

    public static void SaveFloat(string name, float data)
    {
        PlayerPrefs.SetFloat(name, data);
    }

    public static void SaveString(string name, string data)
    {
        PlayerPrefs.SetString(name, data);
    }

    public static void SaveColor(string name, Color color)
    {
        PlayerPrefs.SetFloat(name + "r", color.r);
        PlayerPrefs.SetFloat(name + "g", color.g);
        PlayerPrefs.SetFloat(name + "b", color.b);
        PlayerPrefs.SetFloat(name + "a", color.a);
    }


    public static bool LoadBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1;
    }

    public static int LoadInt(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    public static float LoadFloat(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }

    public static string LoadString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    public static Color LoadColor(string name)
    {
        return new Color(
        PlayerPrefs.GetFloat(name + "r"),
        PlayerPrefs.GetFloat(name + "g"),
        PlayerPrefs.GetFloat(name + "b"),
        PlayerPrefs.GetFloat(name + "a"));
    }
}