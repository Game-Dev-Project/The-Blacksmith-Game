using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(EnemyAI))]

public class Enemy : Mover
{
    [Header("Enemy Parameters")]
    protected string enemyName;
    protected float attackRadius = 5f;
    [SerializeField] private GameObject Weapon;
    [SerializeField] private Transform playerPos;
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
        playerPos = GameObject.Find("Player").transform;
    }

    public virtual void Attack(Vector2 directionToTarget)
    {
        if (attackRateTimer <= 0)
        {
            if (playerPos.position.x < transform.position.x)
            {
                anim.SetTrigger("th_Left");
            }
            else
            {
                anim.SetTrigger("th_Right");
            }
            StartCoroutine(throwBone());
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
        StartCoroutine(killAnimation());
    }

    private IEnumerator throwBone()
    {
        Transform newBoneLoaction = transform.GetChild(0).gameObject.GetComponent<Transform>();

        yield return new WaitForSeconds(0.4f);
        GameObject newBone = Instantiate(Weapon, newBoneLoaction.position, Quaternion.identity);
        newBone.GetComponent<ObjectThrown>().player = playerPos;
        newBone.GetComponent<EnemyAttack>().setCharacterDamageAmount(baseDamage);
    }

    private IEnumerator killAnimation()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
