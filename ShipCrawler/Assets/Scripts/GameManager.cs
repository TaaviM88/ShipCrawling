using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Add Stage boss and player and levelEndTrigger")]
    public GameObject player;
    public GameObject levelBoss;
    public GameObject levelEndTrigger;
    [Header("Next scene number")]
    public int nextSceneIndex = 0;

    bool isBossAlive, isPlayerAlive;

    

    public void Awake()
    {
        if(player == null)
        {
            Debug.Log($"{this.gameObject.name} can't find player.");
        }
        else
        {
            isPlayerAlive = false;
        }

        if (levelBoss == null)
        {
            Debug.Log($"{this.gameObject.name} can't find level boss.");
        }
        else
        {
            isBossAlive = true;
        }
    }


    private void Update()
    {
        if(levelBoss == null && isBossAlive)
        {
            BossIsDead();
            isBossAlive = false;
        }
    }


    public void BossIsDead()
    {
        levelEndTrigger.SetActive(true);
        Journal.Instance.Log("Go to boat and press action button. YOU FAGGOT!");
        
    }
}
