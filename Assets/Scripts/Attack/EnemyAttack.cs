using UnityEngine;

// put this on the weapon of the ENEMY
public class EnemyAttack : WeaponAttack
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            Player p = coll.GetComponent<Player>();
            if (p)
            {
                Damage sumDamage = base.calculateSumDamage();
                p.TakeDamage(sumDamage);
                Debug.Log("PLAYER got hit by " + sumDamage.damageAmount + " point");
                Destroy(gameObject);
            }
        }
        else if (!coll.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
