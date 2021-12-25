using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollCure : Collidable
{
    [SerializeField] private float cure = 0.5f;
    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.Contains("Player"))
        {
            Debug.Log("cure is collected");
            Player p = coll.GetComponent<Player>();
            if (p)
            {
                p.TakeHeal(cure);
                Destroy(gameObject);
            }
        }
    }
}
