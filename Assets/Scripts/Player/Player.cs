using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Mover
{
    Camera cam;

    bool updatedStationary = true;
    private float xSpeed = 0f;
    private float ySpeed = 0f;

    // Player sword
    private GameObject childSword;
    private Animator swordAnim;
    private List<Sword> allWeapons = new List<Sword>(); // hold details of the weapons
    private List<int> allSketchs = new List<int>(); // hold the sketchs of the Swords
    private int currentSword = -1;
    private int diamondRed = 0;
    private int diamondBlue = 0;
    private int diamondGreen = 0;
    private bool isTalking = false;
    private Transform resetPoint;

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
        // for movement
        xSpeed = Input.GetAxisRaw("Horizontal");
        ySpeed = Input.GetAxisRaw("Vertical");

        // adjusment the sprite of the player by the current direction movement
        if (!(xSpeed != 0 && ySpeed != 0))
        {
            anim.SetFloat("moveX", xSpeed);
            anim.SetFloat("moveY", ySpeed);
        }

        // check if player can attack - if true -> attack
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

        // change weapons - go to the  = E -> next weapon, Q -> previous weapon
        if (Input.GetKeyDown(KeyCode.E))
        {
            int size = allWeapons.Count;
            if (size > 0)
            {
                currentSword++;
                if (currentSword >= size)
                {
                    currentSword = 0;
                }
                switchSword(allWeapons[currentSword]);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            int size = allWeapons.Count;
            if (size > 0)
            {
                currentSword--;
                if (currentSword < 0)
                {
                    currentSword = size - 1;
                }
                switchSword(allWeapons[currentSword]);
            }
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
            Sword newSword = coll.GetComponent<CollSword>().getSword();
            // if (allSketchs.Contains(newSword.num))
            // {
            switchSword(newSword);
            allWeapons.Add(newSword);
            Destroy(coll.gameObject);
            // }
            // else
            // {
            //     Debug.Log("you need to collect the sketch -" + newSword.num + "- first");
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
        if (currentSword >= 0)
        {
            swordAnim.SetTrigger(currentSword.ToString());
        }
        else
        {
            Debug.Log("need to activate a fist animtion for the player");
        }
    }

    protected override void KillSelf()
    {
        resetPoint = GameObject.Find("Reset Point").transform;
        Debug.Log(gameObject.name + " got: " + hitPoints + ", Killing player");
        transform.position = resetPoint.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        hitPoints = maxHitPoints;
    }

    private void switchSword(Sword newSword)
    {
        Damage newDamage = newSword.GetDamage();
        childSword.GetComponent<SpriteRenderer>().sprite = newSword.sprite; // put the sprite on childSword
        childSword.GetComponent<PlayerAttack>().setSelfDamage(newDamage);   // put the damage on childSword
        currentSword = newSword.num;
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

    public bool getIsTalking ()
    {
        return isTalking;
    }
    public void setIsTalking(bool istalking)
    {
        isTalking= istalking;
    }
}