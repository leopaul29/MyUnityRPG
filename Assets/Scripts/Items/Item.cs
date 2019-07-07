using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// to create an object in the editor
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
// ScriptableObject is like a blueprint, not a GameObject
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public Sprite Icon = null;
    [Range(1, 999)]
    public int MaximumStacks = 1;
    public int Rarity { get; set; }
    public string ObjectSlug;

    protected static readonly StringBuilder sb = new StringBuilder();

#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }
#endif

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }

    public virtual string GetItemType()
    {
        return "";
    }

    public virtual string GetDescription()
    {
        return "";
    }

    // when click on it in the inventory
    public virtual void Use()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using item " + ItemName);

        // Used as Currency, for crafting
        // have direct effect (potion, etc..)
        // be equip to the character
    }

    public void RemoveFromInventory()
    {
        InventoryManager.instance.Remove(this);
    }
}