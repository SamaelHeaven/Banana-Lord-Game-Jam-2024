using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShop : MonoBehaviour
{

    [SerializeField] private Transform uiShop;
    public bool isShopActive { get; set; } = false;

    public void ToggleShop()
    {
        if (isShopActive)
        {
            PlayerActivator.SetActive(false);
            uiShop.gameObject.SetActive(false);
            isShopActive = false;
        }
        else
        {
            PlayerActivator.SetActive(true);
            uiShop.gameObject.SetActive(true);
            isShopActive = true;
        }
    }
}
