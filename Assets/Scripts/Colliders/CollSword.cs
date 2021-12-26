using UnityEngine;

public class CollSword : Collidable
{
    [SerializeField] private Sword sword;

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        // if (coll.tag == "Player")
        // {
        //     Destroy(this.gameObject);
        // }
    }

    public Sword getSword()
    {
        return sword;
    }
}
