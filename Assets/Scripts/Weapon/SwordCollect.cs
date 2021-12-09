using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SwordCollect : MonoBehaviour
{
    private BoxCollider2D BoxCollider;
    private Rigidbody2D Rigidbody;
    [SerializeField] private float damageAmount;
    [SerializeField] private float pushForce;
    [SerializeField] private Vector3 origin;
    private Damage damage;

    protected virtual void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        damage.damageAmount = damageAmount;
        damage.pushForce = pushForce;
        damage.origin = origin;
    }

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    public Damage getDamage()
    {
        return damage;
    }
}
