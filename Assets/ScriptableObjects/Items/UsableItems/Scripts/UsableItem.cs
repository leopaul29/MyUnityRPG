using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Usable Item")]
public class UsableItem : ItemObject
{
    public bool IsConsumable;

    public List<UsableItemEffect> Effects;

    public virtual void Use(Character character)
    {
        base.Use();

        // check if can be used
        foreach (UsableItemEffect effect in Effects)
        {
            if(!effect.CanExecuteEffect(this, character))
            {
                return;
            }
        }

        foreach (UsableItemEffect effect in Effects)
        {
            effect.ExecuteEffect(this, character);
        }

        // Remove it from the inventory
        RemoveFromInventory();
    }

    public override string GetItemType()
    {
        return IsConsumable ? "Consumable" : "Usable";
    }

    public override string GetDescription()
    {
        sb.Length = 0;
        foreach (UsableItemEffect effect in Effects)
        {
            sb.AppendLine(effect.GetDescription());
        }
        return sb.ToString();
    }
}
