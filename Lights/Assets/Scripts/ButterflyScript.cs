using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyScript : MonoBehaviour 
{
    public GameObject player;
    public SpiritFollow spiritFollow;
	public PlayerManager playerManager;
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
            spiritFollow.AddAirSpirit(gameObject, other.gameObject);
			playerManager = other.gameObject.GetComponent<PlayerManager>();
			playerManager.butterflyAttack = true;
        }
	}
}
