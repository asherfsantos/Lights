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
			if(!sliderInstantiated)
			{
				playerManager = other.gameObject.GetComponent<PlayerManager>();
				sliderInstantiated = true;
				Vector3 sliderPosition = new Vector3(-400f + (200f * playerManager.AirSpiritCount), 200f, 0f);
				spiritFollow.AddAirSpirit(gameObject, other.gameObject);
				uiCanvas = GameObject.FindWithTag("UI Canvas");
				currentSlider = Instantiate(butterflySlider, sliderPosition, Quaternion.identity);
				//currentSlider.transform.parent = uiCanvas.transform;
				currentSlider.transform.SetParent(uiCanvas.transform, false);
				//butterflySlider.value = butterflyTimer/maxLifetime;
				playerManager.butterflyAttack = true;
				followingPlayer = true;
			}	
        }
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
		print("Destroying Slider");
		Destroy(currentSlider.gameObject);
		Destroy(gameObject);
	}
}
