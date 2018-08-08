using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public GameObject player;
    public PlayerManager playerManager;
    public SpiritFollow spiritFollow;
    public float frogTimer;
	public float maxLifetime = 12.0f;
	public bool followingPlayer = false;
    // Use this for initialization
    void Start()
    {
        spiritFollow = GetComponent<SpiritFollow>();
        frogTimer = maxLifetime;
		followingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        FrogTimer();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spiritFollow.AddGroundSpirit(gameObject, other.gameObject);
            AddJumps(other.gameObject);
            followingPlayer = true;
        }
    }

    void AddJumps(GameObject player)
    {
        playerManager = player.GetComponent<PlayerManager>();
        playerManager.maxJumps++;
        playerManager.RestoreJumps();
    }

    void FrogTimer()
	{
		if(frogTimer >= 0.0f && followingPlayer)
		{
			frogTimer -= Time.deltaTime;
		}
		else if(frogTimer <= 0.0f)
		{
			followingPlayer = false;
			FrogDies();
		}
	}

    void FrogDies()
	{
		playerManager.GroundSpiritCount--;
        playerManager.maxJumps--;
        if(playerManager.jumpsRemaining > playerManager.maxJumps)
            playerManager.jumpsRemaining = playerManager.maxJumps;
        Destroy(gameObject);
	}
}
