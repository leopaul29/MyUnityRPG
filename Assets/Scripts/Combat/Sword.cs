using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        PlayerManager.instance.playerCombat.OnAttack += PerformAttack;

    }

    public void PerformAttack()
    {
        Debug.Log("Sword basique attack!");
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        Debug.Log("Sword special attack!");
        animator.SetTrigger("Special_Attack");
    }
}
