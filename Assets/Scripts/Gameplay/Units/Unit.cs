using UnityEngine;

public class Unit : MonoBehaviour
{
    public int level = 1;
    public float damage;
    public float hitPoints;
    public float speed;

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

