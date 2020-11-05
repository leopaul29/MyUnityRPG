using UnityEngine;

public abstract class UsableItemEffect : ScriptableObject
{
    public abstract bool CanExecuteEffect(UsableItem parentItem, Character character);

    public abstract void ExecuteEffect(UsableItem parentItem, Character character);

    public abstract string GetDescription();
}