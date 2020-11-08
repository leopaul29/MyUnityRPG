using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Stat Buff")]
public class StatBuffItemEffect : UsableItemEffect
{
    public int AgilityBuff;
    public float Duration;

    public override bool CanExecuteEffect(UsableItem parentItem, Character character)
    {
        return true;
    }

    public override void ExecuteEffect(UsableItem parentItem, Character character)
    {
        StatModifier statModifier = new StatModifier(AgilityBuff, StatModType.Flat, parentItem);
        character.characterStats.Agility.AddModifier(statModifier);
        UIEventHandler.StatsChanged();
        character.StartCoroutine(RemoveBuff(character, statModifier, Duration));
    }

    public override string GetDescription()
    {
        return "Grants " + AgilityBuff + " Agility for " + Duration + " seconds.";
    }

    private static IEnumerator RemoveBuff(Character character, StatModifier statModifier, float duration)
    {
        yield return new WaitForSeconds(duration);
        character.characterStats.Agility.RemoveModifier(statModifier);
        UIEventHandler.StatsChanged();
    }
}
