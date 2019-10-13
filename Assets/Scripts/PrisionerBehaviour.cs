using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrisionerBehaviour : MonoBehaviour
{

    public bool fighting = false;
    public GameObject enemyPrisioner;
    public NavMeshAgent agent;

    private bool interactible = false;
    public Color shinnyColor;
    private Material material;
    private Color normalColor;

    public Animator stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponent<Renderer>().material;
        normalColor = material.color;
        stateMachine = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactible)
        {
            if(Input.GetKeyDown("space"))
            {
                stateMachine.SetBool("fight", true);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //If the player hits the prisioner, then he is interactuable
        if (col.gameObject.name == "Player")
        {
            material.color = shinnyColor;
            interactible = true;
        }

        //If another prisioner hits the prisioner and he is fighthing they will engage on fight
        if (col.gameObject.tag == "Prisioner")
        {
            stateMachine.SetBool("fight", true);
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            material.color = normalColor;
            interactible = false;
        }
    }
}
