using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archery : Defender
{
    public float damagePer = 0.55f;
    public float hitpointsPer = 0.45f;
    public float speedPer = 0.1f;

    CircleCollider2D collier;
    Rigidbody2D rb2d;
    public Archery(int level) : base(level)
    {
        BaseDamage = 7;
        BaseHitPoints = 40;
        BaseSpeed = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate<GameObject>(atkShape, transform.position, Quaternion.identity);
        Initialize(damagePer, hitpointsPer, speedPer);
        cooldownTimerBullet = gameObject.AddComponent<Timer>();
        CoolDown = 1;
        AttackType = AttackType;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
