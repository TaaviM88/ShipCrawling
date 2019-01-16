using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Singleton

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public CharacterCombat playerCombatManager;
    public PlayerStats playerStats;

    void Start()
    {
        playerCombatManager = GetComponent<CharacterCombat>();
        playerStats = GetComponent<PlayerStats>();
        playerStats.OnHealthReachedZero += Die;
    }

    void Die()
    {
        Debug.Log("Player is död.");
            
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
