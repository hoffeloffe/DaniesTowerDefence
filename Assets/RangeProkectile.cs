using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeProkectile : MonoBehaviour
{
    private float dmg;
    private GameObject target;

    private bool targetSet;
    private string type;
    private float velocity = 5;
    private bool stopProjectile;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocity * Time.deltaTime);
    }
}