using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] Vector2 spawnArea;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, spawnArea);
    }

    public void SpawnCoinInArea()
    {
        Vector2 randomPositionInArea;

        randomPositionInArea.x = Random.Range(transform.position.x - spawnArea.x / 2, transform.position.x + spawnArea.x / 2);
        randomPositionInArea.y = Random.Range(transform.position.y - spawnArea.y / 2, transform.position.y + spawnArea.y / 2);

        if (CheckPositionAvaiability(randomPositionInArea))
        {
            Instantiate(coinPrefab, randomPositionInArea, Quaternion.identity);
        }
        else
        {
            SpawnCoinInArea();
        }
    }

    private bool CheckPositionAvaiability(Vector2 position)
    {
        Collider2D colliders = Physics2D.OverlapCircle(position, 1, 10);

        if (colliders != null)
            return false;
        else
            return true;
    }
}
