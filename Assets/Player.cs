using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject target;

    public GameStats gameStats;

    public LayerMask enemyLayers;

    private float nextAttackTime = 0f;

    private string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float distanceToEnemyShort = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < distanceToEnemyShort)
            {
                distanceToEnemyShort = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && distanceToEnemyShort <= gameStats.attackRange)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }

        //if (target.transform.position == this.transform.position)
        //{
        //    //Player take dmg
        //}
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
            return;

        if (nextAttackTime <= 0f)
        {
            Shoot();
            nextAttackTime = 1f / gameStats.attackRate;
        }

        nextAttackTime -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        Laser laser = bulletGO.GetComponent<Laser>();

        if (laser != null)
            laser.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, gameStats.attackRange);
    }
}