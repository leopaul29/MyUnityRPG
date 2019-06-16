using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EquipmentManager found !");
            return;
        }
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    // PlayerStats.OnEquipmentChanged
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        // init new Equipment Array with the length of EquipmentSlot that exist
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        Equipment oldItem = null;

        // Get enum index of item's equipSlot
        int slotIndex = (int)newItem.equipSlot;

        // if there is already something equiped, put it back in bag
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        // Update when equip
        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

    public void UnEquip(int slotIndex)
    {
        // if there is already something equiped, put it back in bag
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            // Update when unequip
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    private void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }
}
