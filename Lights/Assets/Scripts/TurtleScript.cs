using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleScript : MonoBehaviour
{
    public GameObject player;
    public PlayerManager playerManager;
    public SpiritFollow spiritFollow;
    public int defenseBuff = 3;
    public float turtleTimer;
	public float maxLifetime = 15.0f;
	public bool followingPlayer = false;
    public GameObject uiCanvas;
	public Slider turtleSlider;
	public Slider currentSlider;
	public bool sliderInstantiated;
	// Use this for initialization
	void Start ()
    {
		spiritFollow = GetComponent<SpiritFollow>();
        turtleTimer = maxLifetime;
		followingPlayer = false;
        GetComponentInChildren<Light>().enabled = false;
        sliderInstantiated = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		TurtleTimer();
        if (followingPlayer && sliderInstantiated)
			currentSlider.value = turtleTimer/maxLifetime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerManager = other.GetComponent<PlayerManager>();
			Vector3 sliderPosition = new Vector3(-450f + (100f * playerManager.GroundSpiritCount), 240f, 0f);
            uiCanvas = GameObject.FindWithTag("UI Canvas");
			currentSlider = Instantiate(turtleSlider, sliderPosition, Quaternion.identity);
			currentSlider.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			currentSlider.transform.SetParent(uiCanvas.transform, false);
            sliderInstantiated = true;
            spiritFollow.AddGroundSpirit(gameObject, other.gameObject);
            AddDefense(other.gameObject);
            followingPlayer = true;
        }
    }

    void AddDefense(GameObject player)
    {
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
        Destroy(currentSlider.gameObject);
        Destroy(gameObject);
	}
}
