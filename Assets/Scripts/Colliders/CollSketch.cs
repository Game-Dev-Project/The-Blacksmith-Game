using UnityEngine;

public class CollSketch : Collidable
{
    [SerializeField] private int numOfSketch;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            GetComponent<Animator>().SetTrigger("Collect");
        }
    }

    public int getNumOfSketch()
    {
        return numOfSketch;
    }
}
