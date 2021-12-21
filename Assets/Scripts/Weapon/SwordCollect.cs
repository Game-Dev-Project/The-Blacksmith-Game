using UnityEngine;

public class SwordCollect : Collidable
{
    [SerializeField] private float damageAmount;
    [SerializeField] private float pushForce;
    [SerializeField] private Vector3 origin;
    private Damage damage;

    protected override void Start()
    {
        base.Start();
        damage.damageAmount = damageAmount;
        damage.pushForce = pushForce;
        damage.origin = origin;
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        // if (coll.tag == "Player")
        // {
        //     Destroy(this.gameObject);
        // }
    }
    public Damage getDamage()
    {
        return damage;
    }
}