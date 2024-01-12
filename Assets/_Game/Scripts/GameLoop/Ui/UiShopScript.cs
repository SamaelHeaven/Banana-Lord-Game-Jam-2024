using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiShopScript : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplateOne;
    private Transform shopItemTemplateTwo;
    private Transform shopItemTemplateThree;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplateOne = container.Find("item_template_one");
        
        shopItemTemplateTwo = container.Find("item_template_two");
        
        shopItemTemplateThree = container.Find("item_template_three");
        
        gameObject.SetActive(false);
    }
}
