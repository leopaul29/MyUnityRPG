using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject equipmentUI;

    // Equipment Singleton
    EquipmentManager equipment;

    // Get all InventorySlot of the UI
    EquipmentSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        equipment = EquipmentManager.instance;
        equipment.onEquipmentChangedUpdateUI += UpdateUI;

        // find and store all InventorySlots components 
        slots = itemsParent.GetComponentsInChildren<EquipmentSlot>();

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Character"))
        {
            equipmentUI.SetActive(!equipmentUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        // Rewrite the InventorySlot list
        // Go through all items and add them on slot UI or clear the slot
        for (int i = 0; i < slots.Length; i++)
        {
            if (equipment.CurrentEquipment[i] != null)
            {
                slots[i].AddItem(equipment.CurrentEquipment[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
