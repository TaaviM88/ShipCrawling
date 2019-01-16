using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    CharacterStats stats;

    //public RagdollManager ragdoll;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        stats.OnHealthReachedZero += Die;
    }

    public override void Interact()
    {
        print("Interact");
        CharacterCombat combatManager = Player.instance.playerCombatManager;
        combatManager.Attack(stats);
    }

    void Die()
    {
        /*ragdoll.transform.parent = null;
        ragdoll.Setup();*/
        Destroy(gameObject);
    }

}
