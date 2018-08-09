using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightScript : MonoBehaviour 
{
	public GameObject player;
	public PlayerManager playerManager;
	public Light playerLight;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		playerManager = player.GetComponent<PlayerManager>();
		playerLight = GameObject.FindWithTag("Player Light").GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerLight.intensity < (playerManager.AirSpiritCount + playerManager.GroundSpiritCount) * 0.2f)
			playerLight.intensity += Time.deltaTime/2;
		if(playerLight.intensity > (playerManager.AirSpiritCount + playerManager.GroundSpiritCount) * 0.2f)
			playerLight.intensity -= Time.deltaTime/2;	
	}
}
