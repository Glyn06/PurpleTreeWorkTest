﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityForce = 9.8f;

    float currentGravityForce;

    private void Start()
    {
        currentGravityForce = gravityForce;
    }

    private void Update()
    {
        Vector3 gravityVector = new Vector3(0, -currentGravityForce * Time.deltaTime, 0); 
        gameObject.transform.Translate(gravityVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Hit");
            currentGravityForce = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentGravityForce = gravityForce;
    }
}