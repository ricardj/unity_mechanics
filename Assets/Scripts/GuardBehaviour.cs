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

    public GameObject targetPrisioner;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
    }
}
