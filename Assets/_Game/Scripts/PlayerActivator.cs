using UnityEngine;

public class PlayerActivator
{
    public static void SetActive(bool active)
    {
        Object.FindObjectOfType<PlayerMovement>().enabled = active;
        GameObject.Find("Gun").SetActive(active);
    }
}