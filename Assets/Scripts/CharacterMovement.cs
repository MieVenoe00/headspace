using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 targetPosition;
    private bool isMoving = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(
                Mouse.current.position.ReadValue()
            );
            targetPosition = new Vector2(worldPos.x, worldPos.y);
            isMoving = true;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            if (Vector2.Distance(rb.position, targetPosition) < 0.05f)
            {
                isMoving = false;
            }
        }
    }
}