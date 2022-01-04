using UnityEngine;

public class CollFire : Collidable
{
    [SerializeField] private float damage;
    [SerializeField] protected float attackRate = 0.5f;
    private bool canDoDamage = false;
    protected float attackRateTimer;
    private GameObject target;

    protected virtual void Awake()
    {
        attackRateTimer = 0f;
    }

    private void Update()
    {
        if (canDoDamage && attackRateTimer <= 0)
        {
            Player p = target.GetComponent<Player>();
            if (p)
            {
                canDoDamage = true;
                Damage sumDamage = new Damage();
                sumDamage.damageAmount = damage;
                p.TakeDamage(sumDamage);
                attackRateTimer = attackRate;
            }
        }
        else
        {
            attackRateTimer -= Time.deltaTime;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            Player p = coll.GetComponent<Player>();
            if (p)
            {
                canDoDamage = true;
                target = coll.gameObject;
                // Damage sumDamage = new Damage();
                // sumDamage.damageAmount = damage;
                // p.TakeDamage(sumDamage);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            Player p = coll.GetComponent<Player>();
            if (p)
            {
                canDoDamage = false;
            }
        }

    }
}
