using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			transform.parent = other.transform;
			Vector3 newPosition = new Vector3(other.transform.position.x - 1.5f, other.transform.position.y + 0.5f, other.transform.position.z);
			transform.position = newPosition;
		}
	}
}
