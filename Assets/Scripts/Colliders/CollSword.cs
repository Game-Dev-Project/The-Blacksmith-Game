using UnityEngine;
using UnityEngine.UI;

public class CollSword : Collidable
{
    [SerializeField] private Sword sword;

    private ResourcesTxt dmg;
    private ResourcesTxt pushForce;

    private Image imageSword;

    protected override void Start()
    {
        base.Start();
        dmg = GameObject.Find("CanvasSword").transform.GetChild(0).GetComponent<ResourcesTxt>();
        pushForce = GameObject.Find("CanvasSword").transform.GetChild(1).GetComponent<ResourcesTxt>();
        imageSword = GameObject.Find("CanvasSword").transform.GetChild(2).GetComponent<Image>();
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            dmg.newValue = sword.damageAmount;
            pushForce.newValue = sword.pushForce;
            imageSword.sprite = sword.sprite;
        }
    }

    public Sword getSword()
    {
        return sword;
    }
}
