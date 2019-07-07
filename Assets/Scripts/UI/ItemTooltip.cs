using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public GameObject ItemTooltipGO;
    public Text ItemNameText;
    public Text ItemTypeText;
    public Text ItemDescriptionText;

    private void Awake()
    {
        ItemTooltipGO.SetActive(false);
    }

    public void ShowTooltip(Item item)
    {
        ItemNameText.text = item.ItemName;
        ItemTypeText.text = item.GetItemType();
        ItemDescriptionText.text = item.GetDescription();
        ItemTooltipGO.SetActive(true);
    }

    public void HideTooltip()
    {
        ItemTooltipGO.SetActive(false);
    }
}
