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

    float horizontalSpeed;
    float verticalSpeed;

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

        movement.y -= gravity.GetCurrentGravityForce() * Time.deltaTime; //Gravedad
        transform.Translate(movement * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            startDespawnTimer = true;
            movement = Vector2.zero;
        }

        if (collision.gameObject.layer == 9)
        {
            movement = Vector2.zero;
            SpringBox springBox = collision.gameObject.GetComponent<SpringBox>();

            if (springBox != null)
            {
                verticalSpeed = springBox.ApplyVerticalBounceFactor(verticalSpeed);

                horizontalSpeed = springBox.ApplyHorizontallBounceFactor(horizontalSpeed);

                CalculateMovementComponents(horizontalSpeed, verticalSpeed, myAngle);
            }
            else
            {
                Debug.LogError("El objeto " + collision.gameObject.name + " no contiene el componente SpringBox. Tenes que agregarselo o sacarlo del layer SpringBox");
            }
        }
    }

    public void CalculateMovementComponents(float hSpeed, float vSpeed, float angle) {
        movement.x = hSpeed * Mathf.Cos(Mathf.Deg2Rad * angle);
        movement.y = vSpeed * Mathf.Sin(Mathf.Deg2Rad * angle);

        horizontalSpeed = hSpeed;
        verticalSpeed = vSpeed;

        myAngle = angle;
    }
}
