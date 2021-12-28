using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Transform targetPos;
    private float dmg;
    [SerializeField] private GameObject Weapon;
    private EnemyAI AI;
    private Animator anim;

    void Start()
    {
        AI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
        dmg = GetComponent<Enemy>().getBaseDamage();
    }

    public void attack(float damage)
    {
        this.targetPos = AI.getTargetPos();
        if (targetPos.position.x < transform.position.x)
        {
            anim.SetTrigger("th_Left");
        }
        else
        {
            anim.SetTrigger("th_Right");
        }
        StartCoroutine(throwBone());
    }

    private IEnumerator throwBone()
    {
        Transform newBoneLoaction = transform.GetChild(0).gameObject.GetComponent<Transform>();
        yield return new WaitForSeconds(0.4f);
        GameObject newBone = Instantiate(Weapon, newBoneLoaction.position, Quaternion.identity);
        newBone.GetComponent<ObjectThrown>().player = targetPos;
        newBone.GetComponent<EnemyAttack>().setCharacterDamageAmount(dmg);
    }
}
