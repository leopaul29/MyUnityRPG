using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to create an object in the editor
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
// ScriptableObject is like a blueprint, not a GameObject
public class Item : ScriptableObject
{
    // "new" will override the Object.name property
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;                  // Is the item default wear ?

    // when click on it in the inventory
    public virtual void Use()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using " + name);

        // Used as Currency, for crafting
        // have direct effect (potion, etc..)
        // be equip to the character
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
