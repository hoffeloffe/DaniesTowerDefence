using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public int CurrentHp;
    public int Coins;
    public int dmg;
    public float attackRange;
    public float attackRate;
    public int Round;

    // Start is called before the first frame update
    private void Start()
    {
        CurrentHp = 100;
        Coins = 0;
        dmg = 5;
        attackRange = 0.5f;
        attackRate = 2f;
        Round = 10;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}