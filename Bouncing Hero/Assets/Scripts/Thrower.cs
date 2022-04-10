using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Thrower : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform rockSpawnPoint;

    [SerializeField] int minThrowAngle = 20;
    [SerializeField] int maxThrowAngle = 85;

    [SerializeField] float minThrowSpeed = 2;
    [SerializeField] float maxThrowSpeed = 5;

    [SerializeField] float minTimeBetweenThrows = 2.5f;
    [SerializeField] float maxTimeBetweenThrows = 5;

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
                rockInstance.CalculateMovementComponents(throwSpeed, throwAngle);
        }
    }

    private void GenerateRandomValues()
    {
        throwAngle = Random.Range(minThrowAngle, maxThrowAngle);
        throwSpeed = Random.Range(minThrowSpeed, maxThrowSpeed);
        throwTimer = Random.Range(minTimeBetweenThrows, maxTimeBetweenThrows);
    }
}
