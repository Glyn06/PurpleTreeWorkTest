using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    private void Start()
    {
        GenerateRandomValues();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= throwTimer)
        {
            ThrowRock();
            GenerateRandomValues();
            timer = 0;
        }
    }

    private void ThrowRock()
    {
        if (rockPrefab != null)
        {
            GameObject goInstance;
            goInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);

            Rock rockInstance;
            rockInstance = goInstance.GetComponent<Rock>();

            if (rockInstance != null)
            {
                rockInstance.SetRockAngle(throwAngle);
                rockInstance.SetRockSpeed(throwSpeed);
                rockInstance.CalculateMovementComponents();
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
