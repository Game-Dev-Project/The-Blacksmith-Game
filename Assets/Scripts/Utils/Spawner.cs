using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawnRadius;
    [SerializeField] private int numOfEntities;
    [SerializeField] private float timeBetweenAttack;

    [SerializeField]
    [Tooltip("this determines how damage the enemy will be")]
    private float Damage;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < numOfEntities; i++)
        {
            Vector2 positionToSpawn = (Random.insideUnitCircle * spawnRadius) + (Vector2)transform.position;
            // spwan enemy at position which is random by some radius
            GameObject enemy = Instantiate(spawnPrefab, positionToSpawn, Quaternion.identity);
            EnemyAI enemyAi = enemy.GetComponent<EnemyAI>();
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            enemyAi.SetRoaming(transform.position, spawnRadius); // set roaming point and radius.
            enemyComponent.setAttackRate(timeBetweenAttack);
            enemyComponent.setBaseDamage(Damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere((Vector2)transform.position, spawnRadius);
    }
}
