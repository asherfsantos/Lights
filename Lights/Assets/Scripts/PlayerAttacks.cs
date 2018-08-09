using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour 
{
	public PlayerManager playerManager;
	public GameObject primaryAttack;
	public GameObject butterflyAttack;
	// Use this for initialization
	void Start () 
	{
		playerManager = gameObject.GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		HandleInput();
	}

	void HandleInput()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			if(!playerManager.butterflyAttack)
				UsePrimaryAttack();
			else
				UseButterflyAttack();
		}
	}

	void UsePrimaryAttack()
	{
		Instantiate(primaryAttack, transform.position, Quaternion.identity);
	}

	void UseButterflyAttack()
	{
		Instantiate(butterflyAttack, transform.position, Quaternion.identity);
	}
}
