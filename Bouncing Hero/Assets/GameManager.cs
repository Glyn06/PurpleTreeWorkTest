using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] CoinSpawner coinSpawner;
    [SerializeField] int rockQuantityToSpawnCoin;
    [SerializeField] float levelTime;

    float remainingTime;

    int totalCoinsCollected;
    int rocksScoredToSpawnCoin;
    int totalRocksScored;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        remainingTime = levelTime;
    }

    private void Update()
    {
        if (remainingTime <= 0)
        {
            OnGameOver();
        }
        else
        {
            remainingTime -= Time.deltaTime;

            UIManager.instance.SetTimerText(remainingTime.ToString("00"));
        }
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
    }

    public void AddCoin()
    {
        totalCoinsCollected++;
        UIManager.instance.SetCoinCountText(totalCoinsCollected.ToString("00"));
    }

    public void AddRock()
    {
        rocksScoredToSpawnCoin++;
        totalRocksScored++;
        TrySpawnCoin();
        UIManager.instance.SetRockCountText(totalRocksScored.ToString("00"));
    }

    public void TrySpawnCoin()
    {
        if (rocksScoredToSpawnCoin >= rockQuantityToSpawnCoin)
        {
            coinSpawner.SpawnCoinInArea();
            rocksScoredToSpawnCoin = 0;
        }

    }
}
