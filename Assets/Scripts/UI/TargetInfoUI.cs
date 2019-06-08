using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetInfoUI : MonoBehaviour
{
    // to display enemy life
    // enemy = player.focus.EnemyStats

    // contains all enemyInfoUI to update
    public GameObject targetInfoUI;
    PlayerManager playerManager;
    Interactable focus;

    //EnemyStats enemyStats;

    public Image currentHealthbar;
    public Text currentHealthText;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = playerManager.player.GetComponent<PlayerController>();
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

                UpdateEnemyInfo(targetStats);
            }
        }

    }

    private void UpdateEnemyInfo(CharacterStats targetStats)
    {
        // convert value to float to get health pourcent value
        float ratio = (float)targetStats.currentHealth / (float)targetStats.maxHealth;
        if (currentHealthbar != null && currentHealthText != null)
        {
            currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            currentHealthText.text = (ratio * 100).ToString();
        }

        // update name

        // update lvl

        // update manabar
    }

        /*private void UpdateHealthbar()
         {
             // convert value to float to get health pourcent value
             float ratio = (float)playerManager.currentHealth / (float)maxHealth;
             if (currentHealthbar != null && currentHealthText != null)
             {
                 currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
                 currentHealthText.text = (ratio * 100).ToString();
             }
         }*/
 }
