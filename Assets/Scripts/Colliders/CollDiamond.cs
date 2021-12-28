using UnityEngine;
using UnityEngine.UI;

public class CollDiamond : Collidable
{

    [SerializeField]
    [Tooltip("the value of the diamond")] private int value;

    [SerializeField]
    [Tooltip("set the color of the diamond - red = 0, blue = 1, green = 2")] private int type;

    private MineralTxt mineral;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mineral = GameObject.Find("CanvasMineral").transform.GetChild(type).GetComponent<MineralTxt>();
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            Player p = coll.GetComponent<Player>();
            if (p)
            {
                mineral.newValue += value;
                if (type == 0)
                    p.addRed(value);
                else if (type == 1)
                    p.addBlue(value);
                else if (type == 2)
                    p.addBlue(value);
                Destroy(gameObject);
            }
        }
    }
}
