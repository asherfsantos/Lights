using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScript : MonoBehaviour
{
    public GameObject player;
    public PlayerManager playerManager;
    public SpiritFollow spiritFollow;
	// Use this for initialization
	void Start ()
    {
		spiritFollow = GetComponent<SpiritFollow>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spiritFollow.AddGroundSpirit(gameObject, other.gameObject);
            AddDefense(other.gameObject);
        }
    }

    void AddDefense(GameObject player)
    {
        playerManager = player.GetComponent<PlayerManager>();
        playerManager.maxHealth += 3;
        playerManager.health += 3;
    }
}
