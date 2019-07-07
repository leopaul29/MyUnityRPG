using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour, IFrameName
{   
    [Header("Player UI informations")]
    public GameObject FrameInfo;
    public Image AvatarImage;
    public Text NameText;
    public Image CurrentHealthbar;
    public Text CurrentHealthText;
    public Text LevelText;

    PlayerManager playerManager;

    void Awake()
    {
        playerManager = PlayerManager.instance;
        DisplayFrame();
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnPlayerManaChanged += UpdateMana;
        UIEventHandler.OnPlayerLevelChanged += UpdateLevel;
    }

    public void DisplayFrame()
    {
        FrameInfo.SetActive(true);
        UpdateAvatar(playerManager.Player.characterIcon);
        UpdateName(playerManager.Player.CharacterName);
    }

    public void UpdateAvatar(Sprite characterIcon)
    {
        AvatarImage.sprite = characterIcon;
    }

    public void UpdateName(string playerName)
    {
        NameText.text = playerName;
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        // convert value to float to get health pourcent value
        float ratio = (float)currentHealth / (float)maxHealth;
        if (CurrentHealthbar != null && CurrentHealthText != null)
        {
            // update health progress bar
            CurrentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);

            // display percentage life
            //currentHealthText.text = (ratio * 100).ToString() + "%";
            // display current/max
            CurrentHealthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        }
    }

    public void UpdateMana(int currentMana, int maxMana)
    {
        // TODO
    }

    public void UpdateLevel(int level)
    {
        LevelText.text = level.ToString();
    }
 }
