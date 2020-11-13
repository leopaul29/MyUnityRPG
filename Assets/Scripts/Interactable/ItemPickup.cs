using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemPickup : Interactable
{
    public InventoryObject inventoryObject;

    public ItemObject item;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with ItemPickup " + item.name);

        PickUp();
    }

    void PickUp()
    {
        inventoryObject.AddItem(new Item(item), 1);

        Destroy(gameObject);
    }
}
