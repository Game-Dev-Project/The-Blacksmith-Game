using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class NPC : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 5f;

    // roaming variables
    [SerializeField] private readonly float startRoamingWaitTime = 3f;
    [SerializeField] private float roamingRadius = 10f;
    [SerializeField] private Transform roamingPoint;

    private float roamingWaitTime;
    private Vector2 nextPointToRoam;
    protected Vector2 moveDirection;
    private bool facingRight;
    private NPC_dialogue npcDialog;

    protected BoxCollider2D boxCollider2D;
    protected Rigidbody2D rb;

    private Animator animator;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        npcDialog = transform.GetChild(0).GetComponent<NPC_dialogue>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        // start npc roaming
        // StartCoroutine(WaitAndSetRoaming(roamingPoint, roamingRadius));
    }
    private void FixedUpdate()
    {
        if (!npcDialog.enabled)
        {
            Roam();
        }
    }
    // makes the enemy roam randomly on a radius
    private void Roam()
    {
        if (Vector2.Distance(transform.position, nextPointToRoam) < 0.2f)
        {
            if (roamingWaitTime <= 0)
            {
                nextPointToRoam = Random.insideUnitCircle * roamingRadius + (Vector2)roamingPoint.position;
                roamingWaitTime = startRoamingWaitTime;
            }
            else
            {
                roamingWaitTime -= Time.deltaTime;
            }
        }
        UpdateMovement(Mover.DirectionToMove(nextPointToRoam, transform.position));
    }

    private void UpdateMovement(Vector2 directionOfMovement)
    {
        if (directionOfMovement.x <= -0.1f || directionOfMovement.x >= 0.1f)
        {
            animator.SetFloat("MoveX", directionOfMovement.x);
        }
        else
        {
            animator.SetFloat("MoveY", directionOfMovement.y);
        }

        moveDirection = directionOfMovement.normalized * (movementSpeed * Time.deltaTime);

        // move character
        if (Mathf.Abs(moveDirection.sqrMagnitude) > 0f)
        {
            rb.MovePosition((Vector2)transform.position + moveDirection);
        }

        // flip character
        // if ((moveDirection.x < 0f && facingRight) || (moveDirection.x > 0f && !facingRight))
        // {
        //     facingRight = !facingRight;
        //     transform.Rotate(new Vector2(0, 180));
        // }
    }
}
