using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    PlayerManager playerManager;
    
    [Header("Player UI informations")]
    public Text nameText;
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
        UpdatePlayerInfo();
    }

    private void UpdatePlayerInfo()
    {
        // convert value to float to get health pourcent value
        float ratio = (float)playerManager.playerStats.currentHealth / (float)playerManager.playerStats.maxHealth.GetValue();
        if (currentHealthbar != null && currentHealthText != null)
        {
            currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            currentHealthText.text = (ratio * 100).ToString();
        }

        // update name
        nameText.text = playerManager.playerName;

        // update lvl

        // update manabar
    }
 }
