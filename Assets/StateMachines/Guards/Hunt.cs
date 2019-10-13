using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunt : StateMachineBehaviour
{
    NavMeshAgent navMeshAgent;
    public GameObject targetPrisioner;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        targetPrisioner = animator.gameObject.GetComponent<GuardBehaviour>().targetPrisioner;
        navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GuardBehaviour g = animator.gameObject.GetComponent<GuardBehaviour>();
        navMeshAgent.SetDestination(targetPrisioner.GetComponent<Transform>().position);
        Quaternion endRotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
        animator.gameObject.transform.rotation = Quaternion.Lerp(animator.gameObject.transform.rotation, endRotation, 0.2f);
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
