using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform transform;
    FieldOfView fow;
    Animator stateMachine;

    GameObject targetPrisioner;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        fow = GetComponent<FieldOfView>();
        stateMachine = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //We process the things in our site.
        int visibleTargetsCount = fow.visibleTargets.Count;
        for (int i = 0; i < visibleTargetsCount; i++)
        {
            GameObject g = fow.visibleTargets[i];
            if (g.tag == "Prisioner")
            {
                PrisionerBehaviour prisionerBehaviour = g.GetComponent<PrisionerBehaviour>();
                if (prisionerBehaviour.fighting)
                {
                    targetPrisioner = g;
                    stateMachine.SetBool("hunting", true);
                }

            }
        }
    }

    private void LateUpdate()
    {
        //transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
    }
}
