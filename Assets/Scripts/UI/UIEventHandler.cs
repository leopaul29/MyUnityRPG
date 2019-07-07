using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler
{
    #region UPDATE PlayerInfoUI
    /* ------------------- */
    /* UPDATE PlayerInfoUI */
    /* ------------------- */

    // Player.NotifyHealthChanged
    public delegate void PlayerHealthEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;
    public static void PlayerHealthChanged(int currentHealth, int maxHealth)
    {
        Debug.Log("PlayerHealthChanged");
        // PlayerInfoUI.UpdatePlayerHealth
        OnPlayerHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    internal static void UpdateStatsPanel(Player player)
    {
        throw new NotImplementedException();
    }

    public delegate void PlayerManaEventHandler(int currentMana, int maxMana);
    public static event PlayerManaEventHandler OnPlayerManaChanged;
    public static void PlayerManaChanged(int currentMana, int maxMana)
    {
        Debug.Log("PlayerHealthChanged");
        // PlayerInfoUI.UpdatePlayerHealth
        OnPlayerManaChanged?.Invoke(currentMana, maxMana);
    }
    // PlayerLevel.NotifyPlayerLevelChanged
    public delegate void PlayerLevelEventHandler(int level);
    public static event PlayerLevelEventHandler OnPlayerLevelChanged;
    public static void PlayerLevelChanged(int level)
    {
        //Debug.Log("PlayerLevelChanged");
        // PlayerInfoUI.UpdatePlayerLevelChange
        OnPlayerLevelChanged?.Invoke(level);
    }
    #endregion

    #region UPDATE TargetInfoUI
    /* ------------------- */
    /* UPDATE TargetInfoUI */
    /* ------------------- */

    // PlayerFocus.SetFocus & RemoveFocus
    public delegate void PlayerFocusEventHandler();
    public static event PlayerFocusEventHandler OnPlayerFocusChanged;
    public static void PlayerFocusChanged()
    {
        Debug.Log("PlayerFocusChanged");
        // TargetInfoUI.DisplayFrame
        OnPlayerFocusChanged?.Invoke();
    }

    // Enemy.NotifyHealthChanged
    public delegate void TargetHealthEventHandler(int currentHealth, int maxHealth);
    public static event TargetHealthEventHandler OnTargetHealthChanged;
    public static void TargetHealthChanged(int currentHealth, int maxHealth)
    {
        Debug.Log("TargetHealthChanged");
        // TargetInfoUI.UpdateTargetHealth
        OnTargetHealthChanged?.Invoke(currentHealth, maxHealth);
    }
    #endregion

    #region others
    // update stat when equip & unequip
    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;
    public static void StatsChanged()
    {
        // StatPanel.UpdateStats
        OnStatsChanged?.Invoke();
    }
    

    //public delegate void ItemEventHandler(Item item);
    //public static event ItemEventHandler OnItemAddedToInventory;
    //public static event ItemEventHandler OnItemEquipped;


    //public static void ItemAddedToInventory(Item item)
    //{
    //    OnItemAddedToInventory?.Invoke(item);
    //}

    //public static void ItemAddedToInventory(List<Item> items)
    //{
    //    if (OnItemAddedToInventory != null)
    //    {
    //        foreach (Item item in items)
    //        {
    //            OnItemAddedToInventory(item);
    //        }
    //    }
    //}

    //public static void ItemEquipped(Item item)
    //{
    //    OnItemEquipped?.Invoke(item);
    //}
#endregion
}
