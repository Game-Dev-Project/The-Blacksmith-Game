using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(EnemyAI))]

public class Enemy : Mover
{
    [Header("Enemy Parameters")]
    protected string enemyName;
    protected float attackRadius = 2f;
    [SerializeField] private GameObject Weapon;
    public float GetAttackRadius()
    {
        return attackRadius;
    }

    protected override void Awake()
    {
        base.Awake();
        enemyName = gameObject.name;
        movementSpeed = 2f;
    }

    public virtual void Attack(Vector2 directionToTarget)
    {
        // make an if statment wait between shoot
        Debug.Log("Attacking!");

    }


    protected override void KillSelf()
    {
        // add death animation and logic
        Debug.Log(gameObject.name + " got: " + hitPoints + ", Killing self");
        // activate the animation - "die"
        StartCoroutine(activateAnimation());
    }
    private IEnumerator activateAnimation()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
