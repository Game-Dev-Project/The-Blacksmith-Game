using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class rotateSwoosh : MonoBehaviour
{
    private BoxCollider2D BoxCollider;
    private Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    private Animator animSwing;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        animSwing = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animSwing.SetTrigger("attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            // List<T> weaeponSprite.Add(T) = KEEP ALL THE WEAPONS THE PLAYER COLLECTED

            Sprite tempSprite = coll.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("the player collect " + coll.name);
            // destoy enemy
        }
    }
}
