using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    // private Transform targetPos;
    private float dmg;
    // private EnemyAI AI;
    private Animator anim;

    // [SerializeField] float attackBodyRange;
    [SerializeField] private GameObject Weapon;

    void Start()
    {
        // AI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
    }

    public void attack(float damage)
    {
        anim.SetTrigger("attack");
        dmg = damage;
        GameObject newWeapon = Instantiate(Weapon, transform.position, Quaternion.identity);
        newWeapon.GetComponent<EnemyAttack>().setCharacterDamageAmount(dmg);
    }
}
