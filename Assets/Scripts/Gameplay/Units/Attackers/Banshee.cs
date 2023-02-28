using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banshee : Attacker
{
    public Banshee(int level) : base(level)
    {
    }

    public static float damagePer = 0.5f;
    public static float hitpointsPer = 0.5f;
    public static float speedPer = 0.1f;

    public static float range = 2f;
    public static float selectedRange = 0.5f;
    public static float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        AttackRange = range;
        SelectedRange = selectedRange;
        Debug.Log("Banshee: " + AttackRange);
        Level = 1;
        CoolDown = 1;
        BaseDamage = damage;
        BaseHitPoints = 50;
        BaseSpeed = 15;
        //Damage = BaseDamage * damagePer * Level;


        Initialize(damagePer, hitpointsPer, speedPer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
