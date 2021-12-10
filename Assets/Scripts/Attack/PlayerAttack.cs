using UnityEngine;

// put this on the weapon of the PLYAER
public class PlayerAttack : WeaponAttack
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Enemy"))
        {
            Damage sumDamage = base.calculateSumDamage();
            coll.GetComponent<Enemy>().TakeDamage(sumDamage);
            Debug.Log("ENEMY got hit by " + sumDamage.damageAmount + " points");
        }
    }
}
