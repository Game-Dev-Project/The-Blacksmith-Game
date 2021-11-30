using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;
    [SerializeField] protected float movementSpeed = 5f;
    protected Vector2 moveDirection;
    private bool facingRight;
    bool updatedStationary = true;
    private float xSpeed = 0f;
    private float ySpeed = 0f;
    [SerializeField] Camera cam;

    protected void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // for movement
        xSpeed = Input.GetAxisRaw("Horizontal");
        ySpeed = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        // this function processes players input and updates the moveDirection vector
        if (xSpeed != 0f || ySpeed != 0f)
        {
            UpdateMovement(new Vector2(xSpeed, ySpeed));
            updatedStationary = false;
        }
        else if (!updatedStationary)
        {
            UpdateMovement(new Vector2(0, 0));
            updatedStationary = true;
        }
    }

    public void UpdateMovement(Vector2 directionOfMovement)
    {
        moveDirection = directionOfMovement.normalized * (movementSpeed * Time.deltaTime);
        // move character
        if (Mathf.Abs(moveDirection.sqrMagnitude) > 0f)
        {
            rb.MovePosition((Vector2)transform.position + moveDirection);
        }
        // flip character
        if ((moveDirection.x < 0f && facingRight) || (moveDirection.x > 0f && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector2(0, 180));
        }
    }

    public static Vector2 DirectionToMove(Vector2 moveTo, Vector2 moveFrom)
    {
        return (moveTo - moveFrom);
    }
}
