using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrown : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Transform player;
    private Animator anim;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (target.x == transform.position.x && target.y == transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
