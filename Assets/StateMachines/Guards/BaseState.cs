using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : StateMachineBehaviour
{

	Transform transform;
	float speed = 0.2f;
	Quaternion startRotation;
	Quaternion endRotation;
	bool sight_flag;
	FieldOfView fow;
	Animator stateMachine;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		transform = animator.gameObject.transform;
		startRotation = transform.rotation;
		sight_flag = false;
		fow = animator.gameObject.GetComponent<FieldOfView>();
		stateMachine = animator.gameObject.GetComponent<Animator>();
	}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		//We process the things in our site.
		int visibleTargetsCount = fow.visibleTargets.Count;
		for (int i = 0; i < visibleTargetsCount; i++)
		{

			GameObject g = fow.visibleTargets[i];
			if (g.tag == "Prisioner" && g.name != "Player")
			{
				Debug.Log(g.name);
				PrisionerBehaviour prisionerBehaviour = g.GetComponent<PrisionerBehaviour>();
				if (prisionerBehaviour.stateMachine.GetBool("fight"))
				{
					animator.gameObject.GetComponent<GuardBehaviour>().targetPrisioner = g;
					stateMachine.SetBool("hunting", true);
				}

			}
		}

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
