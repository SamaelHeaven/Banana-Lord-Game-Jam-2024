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

    private void CreateItemButton(string name, string description, int cost, int positionIndex)
    {
        Transform shopItemTransform = null;  // Declare outside the switch statement

        switch (positionIndex)
        {
            default:
            case 1:
                shopItemTransform = Instantiate(shopItemTemplateOne, container);
                break;
            case 2:
                shopItemTransform = Instantiate(shopItemTemplateTwo, container);
                break;
            case 3:
                shopItemTransform = Instantiate(shopItemTemplateThree, container);
                break;
        }

        shopItemTransform.Find("name").GetComponent<TextMeshProUGUI>().SetText(name);
        shopItemTransform.Find("description").GetComponent<TextMeshProUGUI>().SetText(description);
        shopItemTransform.Find("price").GetComponent<TextMeshProUGUI>().SetText(cost.ToString());
        shopItemTransform.gameObject.SetActive(true);
    }
}
