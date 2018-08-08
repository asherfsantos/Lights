using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
	public int health;
	public int maxHealth = 5;
	public int GroundSpiritCount;
	public int AirSpiritCount;
	// Use this for initialization
	void Start () 
	{
		health = maxHealth;
		GroundSpiritCount = 0;
		AirSpiritCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
