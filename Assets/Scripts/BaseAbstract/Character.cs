using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public abstract class Character : MonoBehaviour
{
    [Header("Basic Parameters")]
    [SerializeField] protected float hitPoints;
    [SerializeField] protected float maxHitPoints = 10f;
    [SerializeField] protected float pushRecoverySpeed = 0.2f;
    [SerializeField] protected float immuneTime = 0.5f;
    [SerializeField] protected float baseDamage = 5f;
    [SerializeField] protected float attackRate = 0.5f;
    [SerializeField] protected float attackRange = 2f;
    // [SerializeField] protected Transform attackPosition;

    private float stunnedTime;
    private float startStunnedTime;

    protected float attackRateTimer;

    protected float lastImmune;
    protected Vector3 pushDirection;
    protected BoxCollider2D boxCollider2D;
    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        attackRateTimer = 0f;
        hitPoints = maxHitPoints;
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        lastImmune = 0;

    }

    public void TakeDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            immuneTime = Time.time;
            if (dmg.damageAmount < 0f)
            {
                Debug.Log("Taking negative damage, not possible!");
                return;
            }
            Debug.Log(gameObject.name + " Took " + dmg.damageAmount + " Damage");
            hitPoints -= dmg.damageAmount;
            if (hitPoints <= 0f)
            {
                hitPoints = 0f;
                KillSelf();
            }
        }
    }
    protected virtual void KillSelf()
    {
        // add death animation and logic
        Debug.Log(gameObject.name + " got: " + hitPoints + ", Killing self");
        Destroy(gameObject);
    }

    public void TakeHeal(float healAmount)
    {
        if (healAmount < 0f)
        {
            Debug.Log("Healing negative value, not possible!");
            return;
        }
        Debug.Log(gameObject.name + " healed " + healAmount + " hitPoints");
        hitPoints += healAmount;
        if (hitPoints > maxHitPoints)
        {
            hitPoints = maxHitPoints;
        }
    }

    public float getBaseDamage()
    {
        return baseDamage;
    }

    public void setBaseDamage(float baseDamage)
    {
        this.baseDamage = baseDamage;
    }

    public void setAttackRate(float attackRate)
    {
        this.attackRate = attackRate;
    }
}
