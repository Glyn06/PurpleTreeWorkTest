using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    //Inercia

    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
            Debug.LogError("No hay characther controllern en " + gameObject.name);
    }

    private void Update()
    {
        float hMov = Input.GetAxis("Horizontal");

        Vector3 movementVector;
        movementVector.x = hMov * movementSpeed * Time.deltaTime;
        movementVector.y = 0;
        movementVector.z = 0;

        characterController.Move(movementVector);
    }
}
