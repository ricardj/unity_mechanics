using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProhibitedAreaBehaviour : MonoBehaviour
{

	public static List<GameObject> outRunPrisioners = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
	{

    }

    void OnTriggerEnter(Collider collider)
	{
        if(collider.gameObject.tag == "Prisioner")
		{
			outRunPrisioners.Add(collider.gameObject);
			
		}
	}

    void OnTriggerExit(Collider collider)
	{
        if(collider.gameObject.tag == "Prisioner")
		{
			outRunPrisioners.Remove(outRunPrisioners.Find(g => g.name == collider.gameObject.name));
			
        }
	}
}
