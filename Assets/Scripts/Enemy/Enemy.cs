using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(EnemyAI))]

public class Enemy : Mover
{
    [Header("Enemy Parameters")]
    protected string enemyName;
    protected float attackRadius = 2f;
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
    public virtual void Attack(GameObject target)
    {
        // Debug.Log("Attacking from base");
    }
}
