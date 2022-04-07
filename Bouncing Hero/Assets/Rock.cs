using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float despwanTimer = 2;

    float timer;
    bool startDespawnTimer = false;

    Vector2 movement;
    Gravity gravity;
    float initialSpeed;
    float myAngle;

    // Start is called before the first frame update
    void Awake()
    {
        gravity = GetComponent<Gravity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startDespawnTimer)
        {
            timer += Time.deltaTime;

            if (timer >= despwanTimer)
                Destroy(gameObject);

            movement = Vector2.zero;
        }

        movement.y -= gravity.GetCurrentGravityForce() * Time.deltaTime;
        transform.Translate(movement * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            startDespawnTimer = true;
            movement = Vector2.zero;
        }
    }

    public void CalculateMovementComponents() {
        movement.x = initialSpeed * Mathf.Cos(Mathf.Deg2Rad * myAngle);
        movement.y = initialSpeed * Mathf.Sin(Mathf.Deg2Rad * myAngle);
    }

    public void SetRockSpeed(float speed)
    {
        initialSpeed = speed;
    }

    public void SetRockAngle(float angle)
    {
        myAngle = angle;
    }
}
