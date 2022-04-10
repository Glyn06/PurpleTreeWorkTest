using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class HeroMovement : MonoBehaviour
{

    [SerializeField] GameObject smokePrefab;
    [SerializeField] public float movementSpeed = 5;

    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float hMov = Input.GetAxis("Horizontal");

        Vector2 movementVector;
        movementVector.x = hMov * movementSpeed * Time.deltaTime;
        movementVector.y = 0;

        animator.SetBool("IsWalking", movementVector != Vector2.zero);

        spriteRenderer.flipX = movementVector.x <= 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject smokeGO;
            smokeGO = Instantiate(smokePrefab, transform.position, Quaternion.identity);

            smokeGO.GetComponent<SpriteRenderer>().flipX = spriteRenderer.flipX;
        }

        transform.Translate(movementVector);
    }
}
