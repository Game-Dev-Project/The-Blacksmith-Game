using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollSword : Collidable
{
    [SerializeField] private int numOfSword;
    [SerializeField] private float damageAmount;
    [SerializeField] private float pushForce;
    [SerializeField] private Vector3 origin;
    private Damage damage;

    protected override void Start()
    {
        base.Start();
        damage.damageAmount = damageAmount;
        damage.pushForce = pushForce;
        damage.origin = origin;
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        // if (coll.tag == "Player")
        // {
        //     Destroy(this.gameObject);
        // }
    }
    public Damage getDamage()
    {
        return damage;
    }

    public int getNumOfSword()
    {
        return numOfSword;
    }
}
