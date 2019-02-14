using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyScript : MonoBehaviour 
{
    public GameObject player;
    public SpiritFollow spiritFollow;
	public PlayerManager playerManager;
	public float butterflyTimer;
	public float maxLifetime = 15.0f;
	public bool followingPlayer = false;
	public GameObject uiCanvas;
	public Slider butterflySlider;
	public Slider currentSlider;
	public bool sliderInstantiated;
	AIMovement AIscript;
	public bool Capture = false;
	
	// Use this for initialization
	void Start () 
	{
		spiritFollow = GetComponent<SpiritFollow>();
		butterflyTimer = maxLifetime;
		followingPlayer = false;
		GetComponentInChildren<Light>().enabled = false;
		sliderInstantiated = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ButterflyTimer();
		if (followingPlayer && sliderInstantiated)
			currentSlider.value = butterflyTimer/maxLifetime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.CompareTag("Player"))
        {
			AIscript=GetComponent<AIMovement>();
			Capture=true;

			if(!sliderInstantiated)
			{
				playerManager = other.gameObject.GetComponent<PlayerManager>();
				Vector3 sliderPosition = new Vector3(-450f + (100f * playerManager.AirSpiritCount), 300f, 0f);
				uiCanvas = GameObject.FindWithTag("UI Canvas");
				currentSlider = Instantiate(butterflySlider, sliderPosition, Quaternion.identity);
				currentSlider.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				currentSlider.transform.SetParent(uiCanvas.transform, false);
				sliderInstantiated = true;
				spiritFollow.AddAirSpirit(gameObject, other.gameObject);
				EnableButterflyAttack(other.gameObject);
				followingPlayer = true;
			}	
        }
	}

	void EnableButterflyAttack(GameObject player)
	{
		playerManager.butterflyAttack = true;
	}

	void ButterflyTimer()
	{
		if(butterflyTimer >= 0.0f && followingPlayer)
		{
			butterflyTimer -= Time.deltaTime;
		}
		else if(butterflyTimer <= 0.0f)
		{
			followingPlayer = false;
			ButterflyDies();
		}
	}

	void ButterflyDies()
	{
		playerManager.butterflyAttack = false;
		playerManager.AirSpiritCount--;
		Destroy(currentSlider.gameObject);
		Destroy(gameObject);
	}
}
