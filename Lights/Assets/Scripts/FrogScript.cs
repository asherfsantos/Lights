using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogScript : MonoBehaviour
{
    public GameObject player;
    public PlayerManager playerManager;
    public SpiritFollow spiritFollow;
    public float frogTimer;
	public float maxLifetime = 12.0f;
	public bool followingPlayer = false;
    public GameObject uiCanvas;
	public Slider frogSlider;
	public Slider currentSlider;
	public bool sliderInstantiated;

    // Use this for initialization
    void Start()
    {
        spiritFollow = GetComponent<SpiritFollow>();
        frogTimer = maxLifetime;
		followingPlayer = false;
        GetComponentInChildren<Light>().enabled = false;
        sliderInstantiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        FrogTimer();
        if (followingPlayer && sliderInstantiated)
			currentSlider.value = frogTimer/maxLifetime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerManager = other.GetComponent<PlayerManager>();
			Vector3 sliderPosition = new Vector3(-450f + (100f * playerManager.GroundSpiritCount), 200f, 0f);
            uiCanvas = GameObject.FindWithTag("UI Canvas");
			currentSlider = Instantiate(frogSlider, sliderPosition, Quaternion.identity);
			currentSlider.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			currentSlider.transform.SetParent(uiCanvas.transform, false);
            sliderInstantiated = true;
            spiritFollow.AddGroundSpirit(gameObject, other.gameObject);
            AddJumps(other.gameObject);
            followingPlayer = true;
        }
    }

    void AddJumps(GameObject player)
    {
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
        Destroy(currentSlider.gameObject);
        Destroy(gameObject);
	}
}
