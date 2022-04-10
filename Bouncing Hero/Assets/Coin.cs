using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float timeToDespawn;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToDespawn)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            GameManager.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
