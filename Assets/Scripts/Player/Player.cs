using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    bool updatedStationary = true;
    private float xSpeed = 0f;
    private float ySpeed = 0f;
    [SerializeField] Camera cam;

    private Vector2 weaponPos;

    // private float weaponPosRadius = 0.1f; // ? - put on the sword or on the character
    Vector2 mousePos;
    Vector2 directionToMouse;
    protected override void Awake()
    {
        base.Awake();
        attackRateTimer = attackRate;
        attackRange = 0.2f;
    }
    private void Update()
    {
        // center of the circle
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // get mouse position
        // directionToMouse = mousePos - (Vector2)transform.position; // direction to the mouse
        // directionToMouse = Vector2.ClampMagnitude(directionToMouse, weaponPosRadius); // we clamp the direction vector to threshhold
        // weaponPos = directionToMouse + (Vector2)transform.position; // apply direction with center

        // for movement
        xSpeed = Input.GetAxisRaw("Horizontal");
        ySpeed = Input.GetAxisRaw("Vertical");

        anim.SetFloat("moveX", xSpeed);
        anim.SetFloat("moveY", ySpeed);
    }
    private void FixedUpdate()
    {
        /*
           this function processes players input and updates the moveDirection vector
        */
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
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Weapon")
        {
            // List<T> weaeponSprite.Add(T) = KEEP ALL THE WEAPONS THE PLAYER COLLECTED
            Sprite tempSprite = coll.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("the player collect " + tempSprite.name);
            GameObject ChildGameObject = this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            ChildGameObject.GetComponent<SpriteRenderer>().sprite = tempSprite;
        }
    }
}
