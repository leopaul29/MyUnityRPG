using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemPickup : Interactable
{
    //public static event  Action<ItemPickup> OnAnyItemPickedUp = delegate { };

    public ItemObject item;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with ItemPickup " + item.ItemName);

        PickUp();
    }

    void PickUp()
    {
        // Add to inventory
        bool wasPickedUp = InventoryManager.instance.Add(item);

        if(wasPickedUp)
        {
            Destroy(gameObject);
        }

        //OnAnyItemPickedUp(this);
    }
}
