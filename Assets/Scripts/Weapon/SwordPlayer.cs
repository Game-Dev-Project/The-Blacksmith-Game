using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlayer : MonoBehaviour
{
    [SerializeField] private Damage swordDamage;
    private float playerDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Enemy"))
        {
            Damage sumDamage = new Damage();
            sumDamage.damageAmount = swordDamage.damageAmount + playerDamage;
            coll.GetComponent<Enemy>().TakeDamage(sumDamage);
            Debug.Log("damge = " + sumDamage.damageAmount);
        }
    }

    public void setPlayerDamage(float playerDamage)
    {
        this.playerDamage = playerDamage;
    }

    public void setSwordDamage(Damage damage)
    {
        swordDamage = damage;
    }
}
