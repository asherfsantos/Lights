using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyScript : MonoBehaviour 
{
    public GameObject player;
    public SpiritFollow spiritFollow;
	public PlayerManager playerManager;
	public float butterflyTimer;
	public float maxLifetime = 15.0f;
	public bool followingPlayer = false;
	
	// Use this for initialization
	void Start () 
	{
		spiritFollow = GetComponent<SpiritFollow>();
		butterflyTimer = maxLifetime;
		followingPlayer = false;
		GetComponentInChildren<Light>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ButterflyTimer();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.CompareTag("Player"))
        {
            spiritFollow.AddAirSpirit(gameObject, other.gameObject);
			playerManager = other.gameObject.GetComponent<PlayerManager>();
			playerManager.butterflyAttack = true;
			followingPlayer = true;
        }
	}

	void ButterflyTimer()
	{
		if(butterflyTimer >= 0.0f && followingPlayer)
		{
			butterflyTimer -= Time.deltaTime;
		}
		else if(butterflyTimer <= 0.0f)
		{
			followingPlayer = false;
			ButterflyDies();
		}
	}

	void ButterflyDies()
	{
		playerManager.butterflyAttack = false;
		playerManager.AirSpiritCount--;
		Destroy(gameObject);
	}
}
