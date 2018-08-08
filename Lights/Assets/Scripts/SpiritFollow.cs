using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritFollow : MonoBehaviour 
{
	public PlayerMovements playerMovements;
	public PlayerManager playerManager;

	public void AddAirSpirit(GameObject spirit, GameObject player)
	{
		playerMovements = player.GetComponent<PlayerMovements>();
		playerManager = player.GetComponent<PlayerManager>();
		Vector3 newPosition = new Vector3();
        spirit.transform.parent = player.transform;
		playerManager.AirSpiritCount++;

        if (playerMovements.facingRight)
        {
            newPosition.x = player.transform.position.x - (1.5f * playerManager.AirSpiritCount);
        }
        else
        {
            newPosition.x = player.transform.position.x + (1.5f * playerManager.AirSpiritCount);
        }
        newPosition.y = player.transform.position.y + 1.0f;
        newPosition.z = player.transform.position.z;
		transform.position = newPosition;
	}

	public void AddGroundSpirit(GameObject spirit, GameObject player)
	{
		playerMovements = player.GetComponent<PlayerMovements>();
		playerManager = player.GetComponent<PlayerManager>();
		Vector3 newPosition = new Vector3();
        spirit.transform.parent = player.transform;
		playerManager.GroundSpiritCount++;

        if (playerMovements.facingRight)
        {
            newPosition.x = player.transform.position.x - (1.5f * playerManager.GroundSpiritCount);
        }
        else
        {
            newPosition.x = player.transform.position.x + (1.5f * playerManager.GroundSpiritCount);
        }
        newPosition.y = player.transform.position.y;;
        newPosition.z = player.transform.position.z;
		transform.position = newPosition;
	}
}
