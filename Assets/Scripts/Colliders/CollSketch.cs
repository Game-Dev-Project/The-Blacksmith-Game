using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollSketch : Collidable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("Collect");
        }
    }
}
