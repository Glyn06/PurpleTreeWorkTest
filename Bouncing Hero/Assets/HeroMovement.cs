using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    public float movementSpeed = 5;

    private void Update()
    {
        float hMov = Input.GetAxis("Horizontal");

        Vector2 movementVector;
        movementVector.x = hMov * movementSpeed * Time.deltaTime;
        movementVector.y = 0;

        transform.Translate(movementVector);
    }
}
