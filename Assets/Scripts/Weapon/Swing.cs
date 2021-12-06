using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : Collideable
{
    private Animator animSwing;
    protected override void Start()
    {
        base.Start();
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

    protected override void OnTriggerEnter2D(Collider2D coll)
    {

    }
}
