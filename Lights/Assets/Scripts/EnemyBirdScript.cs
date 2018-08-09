using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdScript : MonoBehaviour 
{
	public GameObject player;
	public PlayerManager playerManager;
	public int maxHealth = 2;
	public int health;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		playerManager = player.GetComponent<PlayerManager>();
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0)
			EnemyDies();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			playerManager.health--;
		}
	}

	void EnemyDies()
	{
		Destroy(gameObject);
	}
}
