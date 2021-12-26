using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private Transform targetPos;
    private float dmg;
    [SerializeField] private GameObject Weapon; // meybe put somting on his head
    private EnemyAI AI;
    private Animator anim;

    void Start()
    {
        AI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
    }

    public void attack(float damage)
    {
        anim.SetTrigger("attack");
    }
}
