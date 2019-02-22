using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour 
{
	public GameObject player;
	public Rigidbody2D playerBody;
	public PlayerManager playerManager;
	private float moveInput;
	public float speed = 10.0f;
	public bool facingRight = false;
	public float jumpForce = 5;
	//public Animator animator;
	public float horizontalMove = 0f;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		playerBody = player.GetComponent<Rigidbody2D>();
		playerManager = player.GetComponent<PlayerManager>();
	}
	
	void FixedUpdate () 
	{
		moveInput = Input.GetAxis("Horizontal");
		playerBody.velocity = new Vector2(moveInput * speed, playerBody.velocity.y);
		if(!facingRight && moveInput > 0)
			Flip();
		else if(facingRight && moveInput < 0)
			Flip();
		HandleInput();
		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	private void HandleInput()
	{
		/* if(Input.GetKeyDown(KeyCode.Space) && (playerManager.jumpsRemaining > 0))
		{
			playerBody.velocity = Vector2.up * jumpForce;
			playerManager.jumpsRemaining--;
		}*/
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
		{
			playerManager.RestoreJumps();
		}
	}
}
