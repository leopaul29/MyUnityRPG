using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ItemType
{
    Food,
    Equipment,
    Default
}

// to create an object in the editor
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
// ScriptableObject is like a blueprint, not a GameObject
public abstract class ItemObject : ScriptableObject, ITooltipDescription
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;

    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public Sprite Icon = null;
    [Range(1, 100)]
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

    public virtual ItemObject GetCopy()
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

    public string GetTooltipDescription()
    {
        return this.description;
    }
}