using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Character
{
    [SerializeField] protected float movementSpeed = 5f;
    protected Vector2 moveDirection;
    private bool facingRight;
    protected Animator anim;

    protected override void Awake()
    {
        base.Awake(); // a must on all override of awake, like a constructor.
        anim = GetComponent<Animator>();
    }

    /*
     * Summary: 
            this function updates the movement of the figther.
            this can get ONLY the direction of the point, cant have the point
    */
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
