using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    public Button removeButon;

    EquipmentObject item;

    public void AddItem(EquipmentObject newItem)
    {
        item = newItem;

        icon.sprite = item.Icon;
        // visible
        icon.enabled = true;
        removeButon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        // not visible
        icon.enabled = false;
        removeButon.enabled = false;
    }

    public void OnRemoveButton()
    {
        EquipmentManager.instance.UnEquip((int)item.equipSlotName);
    }
}
