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

        // init new Equipment Array with the length of EquipmentSlot that exist
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlotNames)).Length;
        CurrentEquipment = new Equipment[numSlots];
    }
    #endregion

    public Equipment[] CurrentEquipment { get; private set; }

    // PlayerStats.OnEquipmentChanged
    public delegate void OnEquipmentChangedUpdateStats(Equipment newItem, Equipment oldItem);
    public OnEquipmentChangedUpdateStats onEquipmentChangedUpdateStats;

    // EquipmentUI.UpdateUI
    public delegate void OnEquipmentChangedUpdateUI();
    public OnEquipmentChangedUpdateUI onEquipmentChangedUpdateUI;

    InventoryManager inventory;

    void Start()
    {
        inventory = InventoryManager.instance;
    }

    public void Equip (Equipment newItem)
    {
        Equipment oldItem = null;

        // Get enum index of item's equipSlot
        int slotIndex = (int)newItem.equipSlotName;

        // if there is already something equiped, put it back in bag
        if (CurrentEquipment[slotIndex] != null)
        {
            oldItem = CurrentEquipment[slotIndex];

            inventory.Add(oldItem);
        }

        CurrentEquipment[slotIndex] = newItem;

        // Update when equip
        // add stats
        newItem.Equip(PlayerManager.instance.Player);
        /*if (onEquipmentChangedUpdateStats != null)
        {
            onEquipmentChangedUpdateStats.Invoke(newItem, oldItem);
        }*/
        // update equipment UI
        if (onEquipmentChangedUpdateUI != null)
        {
            onEquipmentChangedUpdateUI.Invoke();
        }
    }

    public void UnEquip(int slotIndex)
    {
        // if there is already something equiped, put it back in bag
        if (CurrentEquipment[slotIndex] != null)
        {
            Equipment oldItem = CurrentEquipment[slotIndex];

            inventory.Add(oldItem);

            CurrentEquipment[slotIndex] = null;

            // Update when unequip
            // remove stat
            oldItem.Unequip(PlayerManager.instance.Player);
            /*if (onEquipmentChangedUpdateStats != null)
            {
                onEquipmentChangedUpdateStats.Invoke(null, oldItem);
            }*/
            // update equipment UI
            if (onEquipmentChangedUpdateUI != null)
            {
                onEquipmentChangedUpdateUI.Invoke();
            }
        }
    }

    private void UnEquipAll()
    {
        for (int i = 0; i < CurrentEquipment.Length; i++)
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
