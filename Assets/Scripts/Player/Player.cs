using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    bool updatedStationary = true;
    private float xSpeed = 0f;
    private float ySpeed = 0f;
    [SerializeField] Camera cam;

    [SerializeField] private Animator swordAnim;
    private Vector2 weaponPos;

    private float weaponPosRadius = 0.1f;
    Vector2 mousePos;
    Vector2 directionToMouse;
    protected override void Awake()
    {
        base.Awake();
        attackRateTimer = attackRate;
        // attackRange = 0.2f;
    }
    private void Update()
    {
        // center of the circle
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // get mouse position
        directionToMouse = mousePos - (Vector2)transform.position; // direction to the mouse
        directionToMouse = Vector2.ClampMagnitude(directionToMouse, weaponPosRadius); // we clamp the direction vector to threshhold
        weaponPos = directionToMouse + (Vector2)transform.position; // apply direction with center

        // for movement
        xSpeed = Input.GetAxisRaw("Horizontal");
        ySpeed = Input.GetAxisRaw("Vertical");

        anim.SetFloat("moveX", xSpeed);
        anim.SetFloat("moveY", ySpeed);

        // add  timeBetween Mouse press // Aviel
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
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

    private void Attack()
    {
        // acivate the animator of sword
        swordAnim.SetTrigger("attack");
        // StartCoroutine(Attack());
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(weaponPos, attackRange, (int)Layers.Enemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            Damage dmg = new Damage();
            dmg.damageAmount = getBaseDamage();
            Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
            enemy.TakeDamage(dmg);
            Debug.Log("Attacking " + enemy + " With damage of: " + dmg.damageAmount);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

    // private IEnumerator Attack()
    // {
    //     yield return new WaitForSeconds(0.6f);
    //     Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(weaponPos, attackRange, (int)Layers.Enemy);
    //     for (int i = 0; i < enemiesToDamage.Length; i++)
    //     {
    //         Damage dmg = new Damage();
    //         dmg.damageAmount = getBaseDamage();
    //         Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
    //         enemy.TakeDamage(dmg);
    //         Debug.Log("Attacking " + enemy + " With damage of: " + dmg.damageAmount);
    //     }
    // }
}
