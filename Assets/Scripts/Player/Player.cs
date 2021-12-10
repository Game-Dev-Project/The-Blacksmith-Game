using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Mover
{
    [SerializeField] Camera cam;

    [SerializeField]
    [Tooltip("decide wich scene the game will show when the player is DEAD")]
    string sceneName;
    bool updatedStationary = true;
    private float xSpeed = 0f;
    private float ySpeed = 0f;

    private Vector2 weaponPos;

    private float weaponPosRadius = 0.1f;
    Vector2 mousePos;
    Vector2 directionToMouse;

    // Player sword
    private GameObject childSword;
    private Animator swordAnim;

    private bool swordHasSprite = false;

    protected override void Awake()
    {
        base.Awake();
        attackRateTimer = attackRate;
    }
    private void Start()
    {
        childSword = this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        childSword.GetComponent<PlayerAttack>().setCharacterDamageAmount(baseDamage);
        swordAnim = childSword.GetComponent<Animator>();
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

        // adjusment the sprite of the player by the current direction movement
        anim.SetFloat("moveX", xSpeed);
        anim.SetFloat("moveY", ySpeed);

        if (attackRateTimer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                attackRateTimer = attackRate;
            }
        }
        else
        {
            attackRateTimer -= Time.deltaTime;
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
            // List<string> weaeponSprite.Add(string) = KEEP ALL THE WEAPONS THE PLAYER COLLECTED
            Sprite newSprite = coll.GetComponent<SpriteRenderer>().sprite;
            Damage newDamage = coll.GetComponent<SwordCollect>().getDamage();
            childSword.GetComponent<SpriteRenderer>().sprite = newSprite;
            childSword.GetComponent<PlayerAttack>().setSelfDamage(newDamage);
            swordHasSprite = true;
        }
    }

    private void Attack()
    {
        // acivate the animator of sword
        if (swordHasSprite)
        {
            swordAnim.SetTrigger("attack");
        }
        else
        {
            Debug.Log("need to activate a fist animtion for the player");
        }
    }

    protected override void KillSelf()
    {
        Debug.Log(gameObject.name + " got: " + hitPoints + ", Killing self");
        Debug.Log("the Player is DEAD!");
        SceneManager.LoadScene(sceneName);

    }
}
