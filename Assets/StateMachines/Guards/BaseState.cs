﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : StateMachineBehaviour
{

	Transform transform;
	float speed = 0.2f;
	Quaternion startRotation;
	Quaternion endRotation;
	bool sight_flag;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		transform = animator.gameObject.transform;
		startRotation = transform.rotation;
		sight_flag = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (sight_flag)
		{
			endRotation = startRotation * Quaternion.Euler(0, 45, 0);
        }
		else
		{
			endRotation = startRotation * Quaternion.Euler(0, -45, 0);
		}
		transform.rotation = Quaternion.RotateTowards(transform.rotation,endRotation , speed);
		if (Quaternion.Angle(transform.rotation, endRotation) < 10)
		{
				sight_flag = !sight_flag;
		}
			



	}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
		animator.setBool("waiting", false);   
   }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
