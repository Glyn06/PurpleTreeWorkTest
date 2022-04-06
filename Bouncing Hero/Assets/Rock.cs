using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float despwanTimer = 2;

    float timer;
    bool startDespawnTimer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startDespawnTimer)
        {
            timer += Time.deltaTime;

            if (timer >= despwanTimer)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            startDespawnTimer = true;
        }
    }
}
