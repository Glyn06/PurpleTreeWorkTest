using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
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
