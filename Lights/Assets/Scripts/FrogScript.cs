using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public GameObject player;
    public PlayerMovements playerScript;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 newPosition = new Vector3();

        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerScript = player.GetComponent<PlayerMovements>();

            transform.parent = other.transform;
            if (playerScript.facingRight)
            {
                newPosition.x = other.transform.position.x - 1.5f;
            }
            else
            {
                newPosition.x = other.transform.position.x + 1.5f;
            }
            newPosition.y = other.transform.position.y;
            newPosition.z = other.transform.position.z;
            transform.position = newPosition;
        }
    }
}
