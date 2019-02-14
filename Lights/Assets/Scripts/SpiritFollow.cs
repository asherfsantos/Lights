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
        if(playerMovements.facingRight)
            Flip();
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
        newPosition.y = player.transform.position.y + 1.8f;
        newPosition.z = player.transform.position.z;
		transform.position = newPosition;
        ActivateSpiritLight(spirit);
	}

	public void AddGroundSpirit(GameObject spirit, GameObject player)
	{
		playerMovements = player.GetComponent<PlayerMovements>();
		playerManager = player.GetComponent<PlayerManager>();
        if(playerMovements.facingRight)
            Flip();
		Vector3 newPosition = new Vector3();
        spirit.transform.parent = player.transform;
		playerManager.GroundSpiritCount++;

        if (playerMovements.facingRight)
        {
            newPosition.x = player.transform.position.x - (1.9f * playerManager.GroundSpiritCount);
        }
        else
        {
            newPosition.x = player.transform.position.x + (1.9f * playerManager.GroundSpiritCount);
        }
        if(spirit.CompareTag("Frog"))
        {
            newPosition.y = player.transform.position.y - 1.1f;
        }
        else if(spirit.CompareTag("Deer"))
        {
            newPosition.y = player.transform.position.y;
        }
        //newPosition.y = player.transform.position.y;
        newPosition.z = player.transform.position.z;
		transform.position = newPosition;
        ActivateSpiritLight(spirit);
	}

    void Flip()
	{
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

    void ActivateSpiritLight(GameObject spirit)
    {
        GetComponentInChildren<Light>().enabled = true;
    }
}
