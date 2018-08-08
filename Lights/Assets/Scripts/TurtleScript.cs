using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScript : MonoBehaviour
{
    public GameObject player;
    public PlayerManager playerManager;
    public SpiritFollow spiritFollow;
    public int defenseBuff = 3;
    public float turtleTimer;
	public float maxLifetime = 15.0f;
	public bool followingPlayer = false;
	// Use this for initialization
	void Start ()
    {
		spiritFollow = GetComponent<SpiritFollow>();
        turtleTimer = maxLifetime;
		followingPlayer = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		TurtleTimer();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spiritFollow.AddGroundSpirit(gameObject, other.gameObject);
            AddDefense(other.gameObject);
            followingPlayer = true;
        }
    }

    void AddDefense(GameObject player)
    {
        playerManager = player.GetComponent<PlayerManager>();
        playerManager.maxHealth += defenseBuff;
        playerManager.health += defenseBuff;
    }

    void TurtleTimer()
	{
		if(turtleTimer >= 0.0f && followingPlayer)
		{
			turtleTimer -= Time.deltaTime;
		}
		else if(turtleTimer <= 0.0f)
		{
			followingPlayer = false;
			TurtleDies();
		}
	}

	void TurtleDies()
	{
		playerManager.maxHealth -= defenseBuff;
		playerManager.GroundSpiritCount--;
        if(playerManager.health > playerManager.maxHealth)
            playerManager.health = playerManager.maxHealth;
        Destroy(gameObject);
	}
}
