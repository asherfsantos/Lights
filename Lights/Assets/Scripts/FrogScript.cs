using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public GameObject player;
    public PlayerManager playerManager;
    public SpiritFollow spiritFollow;
    // Use this for initialization
    void Start()
    {
        spiritFollow = GetComponent<SpiritFollow>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spiritFollow.AddGroundSpirit(gameObject, other.gameObject);
            AddJumps(other.gameObject);
        }
    }

    void AddJumps(GameObject player)
    {
        playerManager = player.GetComponent<PlayerManager>();
        playerManager.maxJumps++;
        playerManager.RestoreJumps();
    }
}
