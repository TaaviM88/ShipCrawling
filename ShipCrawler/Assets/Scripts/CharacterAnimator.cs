﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAnimator : MonoBehaviour
{
    public AnimationClip replaceableAttackAnimation;
    public AnimationClip[] defaultAttackAnimationSet;
    protected AnimationClip[] currentAttackAnimationSet;
    const float locomationAnimationSmoothTime = .1f;
    protected Animator animator;
    protected CharacterCombat combat;
    public AnimatorOverrideController overrideController;
    NavMeshAgent agent;
    Rigidbody rb;
    public bool useNavMeshAgent = true;
    //Used only animator, for walking speed
    float speedPercent;
    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
        //Käytetäänkö navmeshagentti vaiko rigidbodyä. Vihollisilla navmesh agentti. Pelaajalla rigidbody
        if(useNavMeshAgent)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        else
        {
            rb = GetComponent<Rigidbody>();
        }
        
        if(overrideController == null)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
         
        animator.runtimeAnimatorController = overrideController;
        currentAttackAnimationSet = defaultAttackAnimationSet;
        combat.OnAttack += OnAttack;
        combat.OnDefence += OnDefence;
    }

    protected virtual void Update()
    {
        
        if (useNavMeshAgent)
        {
           speedPercent = agent.velocity.magnitude / agent.speed;
        }
        else
        {
            speedPercent = rb.velocity.magnitude;
        }
        animator.SetFloat("SpeedPercent", speedPercent,locomationAnimationSmoothTime,Time.deltaTime);
        animator.SetBool("inCombat", combat.InCombat);
    }
    
    protected virtual void OnAttack()
    {
        animator.SetTrigger("Attack");
        int attackIndex = Random.Range(0, currentAttackAnimationSet.Length);
        overrideController[replaceableAttackAnimation.name] = currentAttackAnimationSet[attackIndex];

    }

    protected virtual void OnDefence()
    {
        animator.SetTrigger("Guard");

    }
}
