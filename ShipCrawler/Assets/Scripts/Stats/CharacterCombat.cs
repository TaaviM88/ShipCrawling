using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = 0.6f;

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
    }

    public void Attack(CharacterStats enemyStats)
    {
        if (attackCooldown <= 0f)
        {
            this.enemyStats = enemyStats;
            attackCooldown = 1f / attackSpeed;
            StartCoroutine(DoDamage(enemyStats, attackDelay));
            

            if (OnAttack != null)
                OnAttack();
        }

    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        print("Start");
        yield return new WaitForSeconds(delay);

        Debug.Log(transform.name + " swings for " + myStats.damage.Getvalue() + " damage");
        Journal.Instance.Log($"{transform.name}swings for {myStats.damage.Getvalue()} damage");
        enemyStats.TakeDamage(myStats.damage.Getvalue());
    }
}
