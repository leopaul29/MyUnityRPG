using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int Level;
    public int CurrentExperience;
    public int RequiredExperience;

    // Start is called before the first frame update
    void Start()
    {
        CombatEvents.OnEnemyDeath += EnemyToExperience;
        Level = 1;

        NotifyPlayerLevelChanged();
    }

    public void NotifyPlayerLevelChanged()
    {
        UIEventHandler.PlayerLevelChanged(Level);
    }

    public void EnemyToExperience(IEnemy enemy)
    {
        GrantExperience(enemy.Experience);
    }

    public void QuestToExperience()
    {
        // Quest.experienceReward
        GrantExperience(0);
    }

    private void GrantExperience(int amount)
    {
        CurrentExperience += amount;

        while(CurrentExperience >= RequiredExperience)
        {
            CurrentExperience -= RequiredExperience;

            LevelUp();
        }
    }

    #region LevelUp algorythme
    public void LevelUp()
    {
        UpdateRequiredExperience();
        UpdateStats();
        GrantTalentPoint();

        Level++;
        NotifyPlayerLevelChanged();
    }

    private void UpdateRequiredExperience()
    {
        RequiredExperience *= 2;
    }

    private void UpdateStats()
    {

    }

    private void GrantTalentPoint()
    {

    }
    #endregion
}
