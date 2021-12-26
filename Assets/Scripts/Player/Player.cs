using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Mover
{
    Camera cam;
    [SerializeField]
    [Tooltip("decide which scene the game will show when the player is DEAD")]
    string sceneName;
    bool updatedStationary = true;
    private float xSpeed = 0f;
    private float ySpeed = 0f;

    private Vector2 weaponPos;

    // private float weaponPosRadius = 0.1f;
    // Vector2 mousePos;
    // Vector2 directionToMouse;

    // Player sword
    private GameObject childSword;
    private Animator swordAnim;
    private Dictionary<int, WeaponSword> allWeapons = new Dictionary<int, WeaponSword>(); // hold the name and the sprite of the weapons
    private List<int> allSketchs = new List<int>(); // hold the sketchs of the Swords
    private int currentSword = 0;
    private int diamondRed = 0;
    private int diamondBlue = 0;
    private int diamondGreen = 0;

    protected override void Awake()
    {
        base.Awake();
        attackRateTimer = attackRate;
    }

    protected override void Start()
    {
        base.Start();
        childSword = this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        childSword.GetComponent<PlayerAttack>().setCharacterDamageAmount(baseDamage);
        swordAnim = childSword.GetComponent<Animator>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        DontDestroyOnLoad(gameObject);
        
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
        if (coll.tag.Equals("Weapon"))
        {
            string newName = coll.name;
            int n = coll.GetComponent<CollSword>().getNumOfSword();
            // if (allSketchs.Contains(n))
            // {
            Sprite newSprite = coll.GetComponent<SpriteRenderer>().sprite;      // get the sprite from the collider
            Damage newDamage = coll.GetComponent<CollSword>().getDamage();   // get the damage details
            childSword.GetComponent<PlayerAttack>().setSelfDamage(newDamage);   // put the damage on childSword
            childSword.GetComponent<SpriteRenderer>().sprite = newSprite;

            WeaponSword newSword = new WeaponSword();
            newSword.name = newName;
            newSword.sprite = newSprite;
            allWeapons.Add(n, newSword);
            currentSword = n;
            Destroy(coll.gameObject);
            // }
            // else
            // {
            //     Debug.Log("you need to collect the sketch -" + n + "- first");
            // }
        }
        // else if (coll.tag.Equals("Sketch"))
        // {
        //     int n = coll.GetComponent<CollSketch>().getNumOfSketch();
        //     allSketchs.Add(n);
        // }
    }

    private void Attack()
    {
        if (currentSword != 0)
        {
            Debug.Log("attack! sword is equal to " + allWeapons[currentSword].name);
            // swordAnim.SetTrigger("attack");
            swordAnim.SetTrigger(currentSword.ToString());
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
        // Destroy(gameObject);
        // SceneManager.LoadScene("Lobby");
    }

    // add diamonds value
    public void addRed(int num)
    {
        diamondRed += num;
    }

    public void addBlue(int num)
    {
        diamondBlue += num;
    }

    public void addGreen(int num)
    {
        diamondGreen += num;
    }
}