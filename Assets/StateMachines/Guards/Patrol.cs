using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{

	GameObject guard;
	GameObject[] waypoints;
	int currentWP;
	NavMeshAgent navMeshAgent;


    void Awake()
	{

		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		guard = animator.gameObject;
		currentWP = 0;
		navMeshAgent = (guard.GetComponent("NavMeshAgent") as NavMeshAgent);
	}

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		if (waypoints.Length == 0) return;
		if (Vector3.Distance(waypoints[currentWP].transform.position, guard.transform.position) < 3.0f)
		{
			currentWP++;
			if (currentWP >= waypoints.Length)
			{
				currentWP = 0;
			}
		}

		navMeshAgent.SetDestination(waypoints[currentWP].transform.position);
		Quaternion endRotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
		animator.gameObject.transform.rotation = Quaternion.Lerp(animator.gameObject.transform.rotation, endRotation, 0.2f);
	}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		animator.SetBool("patrolling", false);
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

