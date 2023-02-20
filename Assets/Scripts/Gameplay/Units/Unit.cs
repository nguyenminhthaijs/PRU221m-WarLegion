using UnityEngine;

public class Unit : MonoBehaviour
{
    public int level;

    private float damage;
    private float hitPoints;
    private float speed;

    private float baseDamage;
    private float baseHitPoints;
    private float baseSpeed;

    public Unit(int level)
    {
        this.level = level;
    }

    public float Damage { get => damage; set => damage = value; }
    public float HitPoints { get => hitPoints; set => hitPoints = value; }
    public float Speed { get => speed; set => speed = value; }

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public float BaseHitPoints { get => baseHitPoints; set => baseHitPoints = value; }
    public float BaseSpeed { get => baseSpeed; set => baseSpeed = value; }

    public virtual void Initialize(float damageMultiplier, float hitpointMultiplier, float speedMultiplier)
    {
        Damage = BaseDamage * damageMultiplier * level;
        HitPoints = BaseHitPoints * hitpointMultiplier * level;
        Speed = BaseSpeed * speedMultiplier * level;
    }


    public virtual void Attack(Unit target)
    {
        target.TakeDamage(damage);
    }

    public virtual void TakeDamage(float amount)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Destroy the game object
        Destroy(gameObject);
    }

    public virtual void LevelUp()
    {
        level++;
    }
}

