using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 5.0f;
    //public float lowJumpMultiplier = 2.0f;
    Rigidbody2D playerBody;

    void Awake ()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if(playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        /*else if (playerBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }*/
    }
}
