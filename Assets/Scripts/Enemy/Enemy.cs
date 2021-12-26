using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// [RequireComponent(typeof(EnemyAI))]

public class Enemy : Mover
{
    [Header("Enemy Parameters")]
    protected string enemyName;
    protected float attackRadius = 5f;
    // private Transform playerPos;

    public float GetAttackRadius()
    {
        return attackRadius;
    }

    protected override void Awake()
    {
        base.Awake();
        attackRateTimer = attackRate;
        enemyName = gameObject.name;
        movementSpeed = 2f;
    }

    public virtual void Attack(Vector2 directionToTarget) // ? delete Vector2
    {
        if (attackRateTimer <= 0)
        {
            if (enemyName.Contains("Skeleton"))
            {
                GetComponent<Skeleton>().attack(baseDamage);
            }
            else if (enemyName.Contains("Wolf"))
            {
                GetComponent<Wolf>().attack(baseDamage);
            }
            attackRateTimer = attackRate;
        }
        else
        {
            attackRateTimer -= Time.deltaTime;
        }
    }

    protected override void KillSelf()
    {
        Debug.Log(gameObject.name + " got: " + hitPoints + " and DEAD");
        // activate the animation - "die"
        try // delete try and catch after verify every enemy has Animtor and has the trigger "die"
        {
            StartCoroutine(killAnimation());
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
            base.KillSelf();
        }
    }

    private IEnumerator killAnimation()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
