using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to create an object in the editor
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public string objectSlug;

    public override void Use()
    {
        base.Use();

        // Equip the item
        EquipmentManager.instance.Equip(this);

        // Remove it from the inventory
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Shoulders, Cape, Chest, Wrists, Gloves, Wraist, Belt, Legs, Feet, Rings, Jewerly, Weapon, Shield }