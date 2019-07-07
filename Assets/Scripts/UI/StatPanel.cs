using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPanel : MonoBehaviour
{
    [SerializeField] StatDisplay[] statDisplays;
    [SerializeField] string[] statNames;

    private CharacterStat[] stats;
    Player player;

    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<StatDisplay>();
        UpdateStatNames();
    }

    public void Start()
    {
        player = PlayerManager.instance.Player;
        UIEventHandler.OnStatsChanged += UpdateStats;
    }

    public void UpdateStats()
    {
        SetStats(player.Armor, player.Strength, player.Agility, player.Intelligence, player.Stamina);
        UpdateStatValues();
    }

    public void SetStats(params CharacterStat[] charStats)
    {
        stats = charStats;

        if (stats.Length > statDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Displays! Add more StatDisplay!");
            return;
        }

        for (int i = 0; i < statDisplays.Length; i++)
        {
            // active only stats in character stats
            statDisplays[i].gameObject.SetActive(i < stats.Length);

            if (i < stats.Length)
            {
                statDisplays[i].Stat = stats[i];
            }
        }
    }

    // call by character when we need to apply our stats values
    public void UpdateStatValues()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            statDisplays[i].UpdateStatValue();
        }
    }

    public void UpdateStatNames()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statDisplays[i].Name = statNames[i];
        }
    }
}
