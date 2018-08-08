using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour 
{
	public PlayerManager playerManager;
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
		if(Input.GetKeyDown(KeyCode.S))
		{
			if(!playerManager.butterflyAttack)
				UsePrimaryAttack();
			else
				UseButterflyAttack();
		}
	}

	void UsePrimaryAttack()
	{
		print("Primary Attack");
	}

	void UseButterflyAttack()
	{
		print("Butterfly Attack");
	}
}
