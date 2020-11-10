using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found !");
            return;
        }
        instance = this;
    }
    #endregion

    public InventoryObject inventoryObject;

    // Listener to call InventoryUI.UpdateUI
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // Inventory size and list
    public int space = 20;
    public List<ItemObject> items = new List<ItemObject>(); // should be a tab

    public bool Add(ItemObject item)
    {
        //if(!item.isDefaultItem)
        //{
        if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false; ;
            }
        //items.Add(item);
        
        inventoryObject.AddItem(item, 1);

            onItemChangedCallback?.Invoke();
        //}

        return true;
    }

    public void Remove(ItemObject item)
    {
        items.Remove(item);

        onItemChangedCallback?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            inventoryObject.Save();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            inventoryObject.Load();
        }
    }
}
