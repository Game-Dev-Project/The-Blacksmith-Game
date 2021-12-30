using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollFire : Collidable
{
    [SerializeField] private float damage;
    // Start is called before the first frame update
    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            Player p = coll.GetComponent<Player>();
            if (p)
            {
                Damage sumDamage = new Damage();
                sumDamage.damageAmount = damage;
                p.TakeDamage(sumDamage);
            }
        }
    }
}
