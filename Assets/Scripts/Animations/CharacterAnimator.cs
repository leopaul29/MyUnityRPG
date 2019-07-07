using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    protected const float LOCOMOTION_ANIMATION_SMOOTH_TIME = .1f;

    public Animator animator;

    //protected CharacterCombat combat;
    //protected CharacterStats stats;
    protected NavMeshAgent navmeshAgent;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }

        navmeshAgent = GetComponent<NavMeshAgent>();

        //combat = GetComponent<CharacterCombat>();
        //stats = GetComponent<CharacterStats>();

        //combat.OnAttack += OnAttack;
        //stats.OnHealthReachedZero += OnDie;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // locomotion animation
        float speedPercent = navmeshAgent.velocity.magnitude / navmeshAgent.speed;
        animator.SetFloat("Speed_Percent", speedPercent, LOCOMOTION_ANIMATION_SMOOTH_TIME, Time.deltaTime);

        // combat idle
        // if inCombat = true && speedPercent <= .1f
        //animator.SetBool("inCombat", combat.InCombat);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    protected virtual void OnSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    protected virtual void OnCastSpell()
    {
        animator.SetTrigger("Cast_Spell");
    }

    protected virtual void OnHit()
    {
        animator.SetTrigger("Hit");
    }

    protected virtual void OnStun()
    {
        animator.SetTrigger("Stun");
    }

    protected virtual void OnSlow()
    {
        animator.SetTrigger("Stun");
    }

    protected virtual void OnDie()
    {
        animator.SetTrigger("Die");
    }
}
