using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Collideable : MonoBehaviour
{
    private BoxCollider2D BoxCollider;
    private Rigidbody2D Rigidbody;

    protected virtual void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(this.gameObject);
    }
}
