using System.Collections;
using UnityEngine;

// put this on the weapon of the PLYAER
public class PlayerAttack : WeaponAttack
{
    [SerializeField] private float waitTime = 0.4f;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Enemy"))
        {
            Enemy e = coll.GetComponent<Enemy>();
            if (e)
            {
                Damage sumDamage = base.calculateSumDamage();
                e.TakeDamage(sumDamage);
                Rigidbody2D rb = coll.GetComponent<Rigidbody2D>();
                rb.isKinematic = false;
                Vector2 distance = coll.transform.position - transform.position;
                distance = distance.normalized * selfdDamage.pushForce;
                rb.AddForce(distance, ForceMode2D.Impulse);
                StartCoroutine(nokBack(rb));
            }
        }
    }

    private IEnumerator nokBack(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(waitTime);
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
    }
}
