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

        PlayerController = PlayerGO.GetComponent<PlayerController>();
        PlayerCombat = PlayerGO.GetComponent<CharacterCombat>();
        //PlayerStats = PlayerGO.GetComponent<PlayerStats>();
        PlayerAnimator = PlayerGO.GetComponent<PlayerAnimator>();
        PlayerLevel = PlayerGO.GetComponent<PlayerLevel>();
        PlayerFocus = PlayerGO.GetComponent<PlayerFocus>();
        Player = PlayerGO.GetComponent<Player>();
    }
    #endregion

    public string PlayerName;
    public GameObject PlayerGO;
    public Player Player;
    public PlayerController PlayerController;
    public CharacterCombat PlayerCombat;
    //public PlayerStats PlayerStats;
    public PlayerAnimator PlayerAnimator;
    public PlayerLevel PlayerLevel;
    public PlayerFocus PlayerFocus;

    public void Start()
    {

        //PlayerStats.OnHealthReachedZero += Die;
    }

    public void Die()
    {
        // Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
