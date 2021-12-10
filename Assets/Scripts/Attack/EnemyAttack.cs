using UnityEngine;

// put this on the weapon of the ENEMY
public class EnemyAttack : WeaponAttack
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            if (coll.name.Equals("Player"))
            {
                Damage sumDamage = base.calculateSumDamage();
                coll.GetComponent<Player>().TakeDamage(sumDamage);
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
