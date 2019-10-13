using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

	public float eulerAnglesY;
	public float eulerAnglesX;
	public float eulerAnglesZ;

	private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
		transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		eulerAnglesX = transform.eulerAngles.x;
		eulerAnglesY = transform.eulerAngles.y;
		eulerAnglesZ = transform.eulerAngles.z;
    }
}
