using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private float dmg;
    private Animator anim;

    [SerializeField] private GameObject Weapon;

    void Start()
    {
        anim = GetComponent<Animator>();
        dmg = GetComponent<Enemy>().getBaseDamage();
    }

    public void attack(float damage)
    {
        anim.SetTrigger("attack");
        GameObject newWeapon = Instantiate(Weapon, transform.position, Quaternion.identity);
        newWeapon.GetComponent<EnemyAttack>().setCharacterDamageAmount(dmg);
    }
}
