using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovements : MonoBehaviour 
{
	private Transform player;
	public PlayerMovements playerMovements;
	private Vector3 target;
	float speed = 5.0f;
	public float projectileDistance = 3.0f;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player").transform;
		playerMovements = player.GetComponent<PlayerMovements>();
		if(playerMovements.facingRight)
			target = new Vector3(player.position.x + projectileDistance, player.position.y, player.position.z);
		else
			target = new Vector3(player.position.x - projectileDistance, player.position.y, player.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if(transform.position == target)
		{
			DestroyProjectile();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy"))
		{
			DestroyProjectile();
		}
	}

	void DestroyProjectile()
	{
		Destroy(gameObject);
	}
}
