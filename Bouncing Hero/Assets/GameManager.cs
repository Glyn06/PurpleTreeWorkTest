using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] CoinSpawner coinSpawner;
    [SerializeField] int rockQuantityToSpawnCoin;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    int totalCoinsCollected;
    int rocksScored;

    public void AddCoin()
    {
        totalCoinsCollected++;
    }

    public void AddRock()
    {
        rocksScored++;
        TrySpawnCoin();
    }

    public void TrySpawnCoin()
    {
        if (rocksScored >= rockQuantityToSpawnCoin)
        {
            coinSpawner.SpawnCoinInArea();
            rocksScored = 0;
        }

    }
}
