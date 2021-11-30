using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Character
{
    protected float currentTime = 0f;
    [SerializeField] public float timeBetweenSpawns = 0.5f;
    [SerializeField] public KeyCode keyToPress;
    private Animator sordAnimation;

    // Start is called before the first frame update
    void Start()
    {
        sordAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > currentTime + timeBetweenSpawns)
        {
            Attack();
            currentTime = Time.time;
        }
    }

    private void Attack()
    {
        sordAnimation.SetTrigger("Attack!"); //show the animation.

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, (int)Layers.Enemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            Damage dmg = new Damage();
            dmg.damageAmount = baseDamage;
            Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
            enemy.TakeDamage(dmg);
            Debug.Log("Attacking " + enemy + " With damage of: " + dmg.damageAmount);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
