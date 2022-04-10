using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class Thrower : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform rockSpawnPoint;

    public int minThrowAngle = 20;
    public int maxThrowAngle = 85;

    public float minThrowSpeed = 2;
    public float maxThrowSpeed = 5;

    public float minTimeBetweenThrows = 2.5f;
    public float maxTimeBetweenThrows = 5;

    float throwAngle;
    float throwSpeed;
    float throwTimer;

    float timer;

    Animator animator;

    private void Start()
    {
        GenerateRandomValues();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        animator.SetBool("Throw", timer >= throwTimer);

        if (timer >= throwTimer)
        {
            timer = 0;
        }
    }

    private void ThrowRock()
    {
        if (rockPrefab != null)
        {
            GenerateRandomValues();

            GameObject goInstance;
            goInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);

            Rock rockInstance;
            rockInstance = goInstance.GetComponent<Rock>();

            if (rockInstance != null)
            {
                rockInstance.CalculateMovementComponents(throwSpeed, throwAngle);
            }
            else
            {
                Debug.LogError("Al prefab " + goInstance.name + " le falta el script Rock");
            }
        }
        else
        {
            Debug.LogError("Falta prefab de la roca en " + gameObject.name);
        }
    }

    private void GenerateRandomValues()
    {
        throwAngle = Random.Range(minThrowAngle, maxThrowAngle);
        throwSpeed = Random.Range(minThrowSpeed, maxThrowSpeed);
        throwTimer = Random.Range(minTimeBetweenThrows, maxTimeBetweenThrows);
    }
}
