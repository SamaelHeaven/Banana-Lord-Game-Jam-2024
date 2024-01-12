using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItemOnClick : MonoBehaviour
{
    
    private Button myButton;
    public UpgradeList.ItemType itemType;
    [SerializeField] private Transform uiShop;
    [SerializeField] private AudioSource levelUp;
    
    [SerializeField] private ControlShop shop;
    
    private void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        levelUp.Play();
        switch (itemType)
        {
            default:
            case UpgradeList.ItemType.ItemOne:
                // 0.03
                Upgrades.ShootingSpeed(0.03f);
                uiShop.gameObject.SetActive(false);
                shop.ToggleShop();
                break;
            case UpgradeList.ItemType.ItemTwo:
                // 10
                Upgrades.Health(10);
                uiShop.gameObject.SetActive(false);
                shop.ToggleShop();
                break;
            case UpgradeList.ItemType.ItemThree:
                // 0.5
                Upgrades.MoveSpeed(0.5f);
                uiShop.gameObject.SetActive(false);
                shop.ToggleShop();
                break;
        }

    }
    
}
