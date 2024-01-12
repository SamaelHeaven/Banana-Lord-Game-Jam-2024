using UnityEngine;

public static class PlayerActivator
{
    public static bool flag = true;
    
    public static void SetActive(bool active)
    {
        flag = active;
    }
}