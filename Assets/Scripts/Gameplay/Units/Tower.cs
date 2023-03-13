using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Unit
{
   

    private void Start()
    {
        BaseHitPoints = 100;
        HitPoints = 100;
    }

    public Tower(int level):base(level)
    {
        Level = level;
    }


   



    
    public override void TakeDamage(float amount)
    {
        Debug.Log("towertake");
        HitPoints -= amount;
         Debug.Log(HitPoints);
         Debug.Log(amount);
        if (HitPoints <= 0)
        {
            Die();
        }
    }


    protected override void Die()
    {
        // Destroy the game object
        Destroy(gameObject);
    }

    public virtual void LevelUp()
    {
        Level++;
    }
}