using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour 
{
	public GameObject player;
	public Rigidbody2D playerBody;
	private float moveInput;
	public float speed = 10.0f;
	private bool facingRight = false;
	public float jumpForce = 5;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		playerBody = player.GetComponent<Rigidbody2D>();
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
		if(Input.GetKeyDown(KeyCode.Space))
		{
			playerBody.velocity = Vector2.up * jumpForce;
		}
	}
}
