using UnityEngine;

public class InventoryUI : MonoBehaviour
{ 
    // contains all InventorySlot to update
    public Transform itemsParent;
    public GameObject inventoryUI;

    // Inventory Singleton
    InventoryManager inventory;

    public InventoryObject inventoryObject;

    // Get all InventorySlot of the UI
    InventorySlotUI[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = InventoryManager.instance;
        inventory.onItemChangedCallback += UpdateUI;

        // find and store all InventorySlots components 
        slots = itemsParent.GetComponentsInChildren<InventorySlotUI>();

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // KeyCode B
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI ()
    {
        // Rewrite the InventorySlot list
        // Go through all items and add them on slot UI or clear the slot
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
