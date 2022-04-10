using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private float gravityForce = 9.8f;

    float originalGravityForce;

    private void Awake()
    {
        originalGravityForce = gravityForce;
    }

    private void Update()
    {
        /*Vector3 gravityVector = new Vector3(0, -currentGravityForce * Time.deltaTime, 0); 
        gameObject.transform.Translate(gravityVector);*/
    }

    public float GetGravityForce() {
        return gravityForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gravityForce = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gravityForce = originalGravityForce;
    }
}
