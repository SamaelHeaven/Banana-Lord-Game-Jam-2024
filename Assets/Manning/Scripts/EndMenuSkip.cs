using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuSkip : MonoBehaviour
{
    [SerializeField] public bool CanSkip;
    [SerializeField] public bool Force = false;

    public void EnableSkip()
    {
        CanSkip = true;
    }

    public void ForceSkip()
    {
        CanSkip = true;
        Force = true;
    }
}
