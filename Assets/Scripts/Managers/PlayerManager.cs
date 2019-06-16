using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameObject))]
public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PlayerManager found !");
            return;
        }
        instance = this;
    }
    #endregion

    public string playerName;
    public GameObject player;
    public CharacterCombat playerCombat;
    public PlayerStats playerStats;
    public PlayerAnimator playerAnimator;

    public void Start()
    {
        playerCombat = player.GetComponent<CharacterCombat>();
        playerStats = player.GetComponent<PlayerStats>();
        playerAnimator = player.GetComponent<PlayerAnimator>();

        playerStats.OnHealthReachedZero += Die;
    }

    public void Die()
    {
        // make timercounter
        new WaitForSeconds(10);

        // Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
