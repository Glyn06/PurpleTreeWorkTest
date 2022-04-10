using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float gravityForce = 9.8f;

    float originalGravityForce;

    private void Awake()
    {
        originalGravityForce = gravityForce;
    }

    public float GetGravityForce()
    {
        return gravityForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            gravityForce = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gravityForce = originalGravityForce;
    }
}
