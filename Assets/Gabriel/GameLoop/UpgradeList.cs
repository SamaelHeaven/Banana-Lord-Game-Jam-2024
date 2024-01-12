using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeList
{
    
    public enum ItemType
    {
        ItemOne,
        ItemTwo,
        ItemThree
    }

    public static int GetCost(ItemType type)
    {
        switch (type)
        {
            default:
                case ItemType.ItemOne: return 5;
                case ItemType.ItemTwo: return 4;
                case ItemType.ItemThree: return 6;
        }
    }
    
}
