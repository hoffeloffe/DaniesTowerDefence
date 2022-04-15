using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject target;

    public GameObject gameStats;

    public float speed = 70f;

    public void Seek(GameObject target)
    {
        this.target = target;
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;

        float distance = speed * Time.deltaTime;

        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
    }

    private void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage(gameStats.GetComponent<GameStats>().dmg);
        Destroy(gameObject);
    }
}