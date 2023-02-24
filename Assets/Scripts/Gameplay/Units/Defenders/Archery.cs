using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archery : Defender
{
    public float damagePer = 0.55f;
    public float hitpointsPer = 0.45f;
    public float speedPer = 0.1f;

    private Attacker currentTarget;
    Timer timer;

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
        timer = gameObject.AddComponent<Timer>();
        //Instantiate<GameObject>(atkShape, transform.position, Quaternion.identity);
        Initialize(damagePer, hitpointsPer, speedPer);
        timer.Duration = 1;
        timer.Run();
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        // Check if the collider belongs to a Defender unit
        Attacker attacker = other.GetComponent<Attacker>();
        if (attacker != null && (currentTarget == null || attacker == currentTarget))
        {
            currentTarget = attacker;
            if (timer.Finished)
            {
                timer.Run();
                Vector2 p = currentTarget.transform.position;
                Vector2 directionTarget = p - new Vector2(transform.position.x, transform.position.y);
                float angle = Mathf.Atan2(directionTarget.y, directionTarget.x) * Mathf.Rad2Deg-90;
                Debug.Log(angle);
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                GameObject bullet = Instantiate<GameObject>(AttackShape, transform.position, Quaternion.identity);
                bullet.transform.rotation = rotation;
                rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.AddForce(directionTarget.normalized * 3, ForceMode2D.Impulse);
            }
          
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
