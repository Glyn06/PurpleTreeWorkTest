using UnityEngine;

[RequireComponent(typeof(Gravity))]
public class Rock : MonoBehaviour
{
    [SerializeField] float despwanTimer = 2;

    float timer;
    bool startDespawnTimer = false;

    SpringBox springBox;

    Vector2 initialPosition;
    Vector2 position;

    Gravity gravity;
    Goal goal;

    float aliveTime;

    float horizontalSpeed;
    float verticalSpeed;

    float myAngle;
    float initialVelocity;

    float maxX;

    bool floorHit;

    void Awake()
    {
        initialPosition = new Vector2(transform.position.x, transform.position.y);

        gravity = GetComponent<Gravity>();
        goal = FindObjectOfType<Goal>();
        springBox = FindObjectOfType<SpringBox>();
    }

    private void Update()
    {
        if (startDespawnTimer)
        {
            timer += Time.deltaTime;

            if (timer >= despwanTimer)
                Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 position;

        aliveTime += Time.fixedDeltaTime;

        if (floorHit)
            position = transform.position;
        else
        {
            position = CalculatePositionOverTime();

            transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            startDespawnTimer = true;

            floorHit = true;
        }

        if (collision.gameObject.layer == 9)
        {
            position = transform.position;

            if (springBox != null)
            {
                float HorizontalPosAfterBounce = transform.position.x + maxX;

                if (HorizontalPosAfterBounce >= goal.transform.position.x)
                {
                    CalculateLastBounce();
                }
                else
                {
                    CalculateBounce();
                }
            }
        }
    }

    private void CalculateBounce()
    {
        initialPosition = transform.position;
        aliveTime = 0;

        horizontalSpeed = springBox.ApplyHorizontallBounceFactor(horizontalSpeed);
        verticalSpeed = springBox.ApplyVerticalBounceFactor(verticalSpeed);

        float newInitialVelocity = horizontalSpeed / Mathf.Cos(Mathf.Deg2Rad * myAngle);

        CalculateMovementComponents(newInitialVelocity, myAngle);
    }

    private void CalculateLastBounce()
    {
        initialPosition = transform.position;
        aliveTime = 0;

        float randomHeight = goal.transform.position.y + Random.Range(3.5f, 5);

        float displacementY = goal.gameObject.transform.position.y - initialPosition.y;
        float displacementX = goal.gameObject.transform.position.x - initialPosition.x;

        float maxHeigth = displacementY + randomHeight;

        float velocityY = Mathf.Sqrt(-2 * -gravity.GetGravityForce() * maxHeigth);
        float velocityX = displacementX / (Mathf.Sqrt(-2 * maxHeigth / -gravity.GetGravityForce()) + Mathf.Sqrt(2 * (displacementY - maxHeigth) / -gravity.GetGravityForce()));

        horizontalSpeed = velocityX;
        verticalSpeed = velocityY;
    }

    public void CalculateMovementComponents(float initialSpeed, float angle)
    {
        initialVelocity = initialSpeed;

        horizontalSpeed = initialSpeed * Mathf.Cos(Mathf.Deg2Rad * angle);
        verticalSpeed = initialSpeed * Mathf.Sin(Mathf.Deg2Rad * angle);

        myAngle = angle;

        CalculateMaxX();
    }

    public Vector2 CalculatePositionOverTime()
    {
        Vector2 positionOverTime;

        positionOverTime.x = horizontalSpeed * aliveTime + initialPosition.x;
        positionOverTime.y = 0.5f * (-gravity.GetGravityForce()) * Mathf.Pow(aliveTime, 2) + verticalSpeed * aliveTime + initialPosition.y;

        return positionOverTime;
    }

    public void CalculateMaxX()
    {
        maxX = (Mathf.Pow(initialVelocity, 2) * Mathf.Sin(Mathf.Deg2Rad * myAngle * 2)) / gravity.GetGravityForce();

        maxX = initialPosition.x + maxX;

        GameManager.instance.SetHeroGuideX(maxX);
    }
}
