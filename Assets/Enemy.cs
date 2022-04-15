using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int hp;
    public Collider collider;
    public NavMeshAgent agent;
    public GameObject Player;
    public GameStats gameStats;
    public float distToGround;
    private int dmg;

    public LayerMask ground;
    public Transform groundCheack;

    private void Start()
    {
        // get the distance to ground
        dmg = gameStats.Round;
    }

    private bool IsGrounded()
    {
        distToGround = collider.bounds.extents.y;
        return Physics.CheckSphere(groundCheack.position, .1f, ground);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            //DeathAnmation
            Destroy(gameObject);
        }
    }

    public void DealDamage()
    {
        //
    }

    private void Update()
    {
        if (IsGrounded())
        {
            agent.SetDestination(Player.transform.position);
        }
    }
}