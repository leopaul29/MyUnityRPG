using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventoryObject;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventoryObject.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventoryObject.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            inventoryObject.Save();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            inventoryObject.Load();
        }
    }
}
