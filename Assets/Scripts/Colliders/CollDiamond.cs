using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollDiamond : Collidable
{
    [SerializeField]
    [Tooltip("the color of the diamond")] private string color;

    [SerializeField]
    [Tooltip("the value of the diamond")] private int value;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            Player p = coll.GetComponent<Player>();
            if (p)
            {
                if (color.Equals("red"))
                {
                    p.addRed(value);
                }
                if (color.Equals("blue"))
                {
                    p.addBlue(value);
                }
                else if (color.Equals("green"))
                {
                    p.addGreen(value);
                }
                Destroy(gameObject);
            }
        }
    }
}
