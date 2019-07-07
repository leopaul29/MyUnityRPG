using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetInfoUI : MonoBehaviour, IFrameName
{
    // contains all enemyInfoUI to update
    // required to display the window target info
    public GameObject FrameInfo;
    public Image AvatarImage;
    public Text NameText;
    public Image CurrentHealthbar;
    public Text CurrentHealthText;
    public Text LevelText;

    PlayerFocus playerFocus;
    Character character;

    void Awake()
    {
        UIEventHandler.OnPlayerFocusChanged += DisplayFrame;
        UIEventHandler.OnTargetHealthChanged += UpdateHealth;
        UIEventHandler.OnTargetHealthChanged += UpdateMana;
    }

    private void Start()
    {
        playerFocus = PlayerManager.instance.PlayerFocus;
    }

    public void DisplayFrame()
    {
        if(playerFocus != null) { 
            Interactable focus = playerFocus.focus;
            //Debug.Log("focus:" + focus.GetType());
            if (focus != null && (focus is EnemyInteraction || focus is NPCInteraction))
            {
                FrameInfo.SetActive(true);

                character = focus.GetComponent<Character>();
                Debug.Log("character:" + character);
                // is it a character to display ?
                if (character != null)
                {
                    UpdateFrameInfo(character);
                }

            } else
            {
                FrameInfo.SetActive(false);
            }
        }
    }

    public void UpdateFrameInfo(Character character)
    {
        UpdateAvatar(character.characterIcon);
        UpdateName(character.CharacterName);
        character.NotifyHealthChanged();
        UpdateLevel(character.Level);
    }

    public void UpdateAvatar(Sprite characterIcon)
    {
        AvatarImage.sprite = characterIcon;
    }

    public void UpdateName(string targetName)
    {
        if(playerFocus.focus is EnemyInteraction)
        {
            NameText.color = Color.red;
        }
        else if(playerFocus.focus is NPCInteraction)
        {
            NameText.color = Color.green;
        }
        else
        {
            NameText.color = Color.yellow;
        }

        NameText.text = targetName;
    }

    public void UpdateHealth(int currentHealth, int maxHealth) 
    {
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

    // Start is called before the first frame update
    /*void Start()
    {
        playerManager = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = playerManager.PlayerController;
        focus = playerController.focus;
        // not display target info
        targetInfoUI.SetActive(false);

        if (focus != null)
        {
            // if got stats, then it's a target focusable (humanoid, beast, enemy, npc)
            CharacterStats targetStats = focus.GetComponent<CharacterStats>();

            if (targetStats != null)
            {
                targetInfoUI.SetActive(true);

                UpdateTargetInfo(focus.interactableName, targetStats);
            }
        }

    }*/
}
