using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollDiamond : Collidable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
