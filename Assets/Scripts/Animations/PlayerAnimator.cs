using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator
{
    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        float speedPercent = GetComponent<CharacterController>().velocity.magnitude / GetComponent<PlayerMovement>().speed;
        animator.SetFloat("Speed_Percent", speedPercent, LOCOMOTION_ANIMATION_SMOOTH_TIME, Time.deltaTime);
    }
}
