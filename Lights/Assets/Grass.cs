﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void onTriggerEnter2D (Collider2D other){
        if (other.CompareTag("Player")){
            anim.SetTrigger ("move");
        }
    }
}
