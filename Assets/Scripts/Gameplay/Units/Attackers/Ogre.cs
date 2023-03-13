using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Attacker
{
    public static float damagePer = 0.5f;
    public static float hitpointsPer = 0.5f;
    public static float speedPer = 0.1f;

    public static float range = 5f;
    public static float selectedRange = 0.5f;
    public static float damage = 14f;

    public Ogre(int level) : base(level)
    {
    }
    
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        AttackRange = range;
        SelectedRange = selectedRange;
        Level = 1;


        CoolDown = 1;
        BaseDamage = damage;
        BaseHitPoints = 80;
        BaseSpeed = 10;

        Initialize(damagePer, hitpointsPer, speedPer);
    }

}
