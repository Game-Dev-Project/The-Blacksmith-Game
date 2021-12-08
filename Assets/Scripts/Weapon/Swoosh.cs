using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swoosh : Collideable
{
    // [SerializeField] private Player player;
    // [SerializeField] private float attackRange = 0.5f;
    // private Vector2 weaponPos;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     weaponPos = new Vector2(transform.position.x, transform.position.y);
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Attack();
    //     }
    // }
    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        // if (coll.tag == "Enemy")
        // {
        //     Damage dmg = new Damage();
        //     dmg.damageAmount = player.getBaseDamage();
        //     Enemy enemy = coll.gameObject.GetComponent<Enemy>();
        //     enemy.TakeDamage(dmg);
        //     Debug.Log("Attacking " + enemy + " With damage of: " + dmg.damageAmount);
        // }
    }

    // private void Attack()
    // {
    //     Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(weaponPos, attackRange, (int)Layers.Enemy);
    //     for (int i = 0; i < enemiesToDamage.Length; i++)
    //     {
    //         Damage dmg = new Damage();
    //         dmg.damageAmount = player.getBaseDamage();
    //         Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
    //         enemy.TakeDamage(dmg);
    //         Debug.Log("Attacking " + enemy + " With damage of: " + dmg.damageAmount);
    //     }
    // }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(weaponPos, attackRange);
    // }
}
