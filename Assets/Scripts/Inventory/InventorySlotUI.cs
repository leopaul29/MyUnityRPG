using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemIcon;
    public Button removeButon;
    public ItemTooltip itemTooltip;

    ItemObject item;

    public void OnValidate()
    {
        if (itemTooltip == null)
            itemTooltip = FindObjectOfType<ItemTooltip>();
    }

    public void AddItem(ItemObject newItem)
    {
        item = newItem;

        itemIcon.sprite = item.Icon;
        itemIcon.enabled = true;
        removeButon.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        itemIcon.sprite = null;
        itemIcon.enabled = false;
        removeButon.interactable = false;
    }

    #region UnityEventResponders
    public void OnRemoveButton()
    {
        InventoryManager.instance.Remove(item);

        // hide the tooltip after removing it
        HideTooltip(this);
    }

    public void UseItem()
    {
        if(item is UsableItem)
        {
            ((UsableItem)item).Use(PlayerManager.instance.Player);
        }
         else if(item != null)
        {
            item.Use();
        }

        // hide the tooltip after use
        HideTooltip(this);
    }
    #endregion

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip(this);
    }

    private void ShowTooltip(InventorySlotUI itemSlot)
    {
        if (itemSlot.item != null)
        {
            itemTooltip.ShowTooltip(itemSlot.item);
        }
    }

    private void HideTooltip(InventorySlotUI itemSlot)
    {
        if (itemTooltip.gameObject.activeSelf)
        {
            itemTooltip.HideTooltip();
        }
    }
}
