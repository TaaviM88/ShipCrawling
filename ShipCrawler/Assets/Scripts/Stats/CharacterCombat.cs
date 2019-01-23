using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = 0.6f;
    float lastAttackTime;
    public bool InCombat { get; private set;}
    public event System.Action OnAttack;
    CharacterStats myStats;
    CharacterStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if(Time.time - lastAttackTime > attackCooldown)
        {
            InCombat = false;
        }
    }

    public void Attack(CharacterStats enemyStats)
    {
        if (attackCooldown <= 0f)
        {
            this.enemyStats = enemyStats;
            attackCooldown = 1f / attackSpeed;
            //StartCoroutine(DoDamage(enemyStats, attackDelay));
            AttackHit_AnimationEvent();

            if (OnAttack != null)
                OnAttack();

            InCombat = true;
            lastAttackTime = Time.time;
        }

    }

    /*IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        print("Start");
        yield return new WaitForSeconds(delay);

        Debug.Log(transform.name + " swings for " + myStats.damage.Getvalue() + " damage");
        Journal.Instance.Log($"{transform.name} swings for {myStats.damage.Getvalue()} damage");
        enemyStats.TakeDamage(myStats.damage.Getvalue());
    }*/

    public void AttackHit_AnimationEvent()
    {
        enemyStats.TakeDamage(myStats.damage.Getvalue());
        Journal.Instance.Log($"{transform.name} swings for {myStats.damage.Getvalue()} damage");
        if (enemyStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }

    public void AttackAnimation()
    {
        OnAttack();
    }
}
