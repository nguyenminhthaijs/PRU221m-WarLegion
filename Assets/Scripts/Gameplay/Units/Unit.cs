using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int level;

    private float damage;
    private float hitPoints;
    private float speed;
    private float attackRange;
    private AttackType attackType;
    private float coolDown;
    protected Timer cooldownTimerBullet;

    private float baseDamage;
    private float baseHitPoints;
    private float baseSpeed;

    Vector2 thrustDirection = new Vector2(1, 0);


    [SerializeField]
    protected GameObject AttackShape;

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
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float CoolDown { get => coolDown; set => coolDown = value; }
    public AttackType AttackType { get => attackType; set => attackType = value; }

    public virtual void Initialize(float damageMultiplier, float hitpointMultiplier, float speedMultiplier)
    {
        Damage = BaseDamage * damageMultiplier * level;
        HitPoints = BaseHitPoints * hitpointMultiplier * level;
        Speed = BaseSpeed * speedMultiplier * level;
    }


    public virtual void Attack(Unit target)
    {
        //if unit are not in attacking state
        if (!cooldownTimerBullet.Running)
        {
            Debug.Log("Shoot");
            cooldownTimerBullet.Duration = 1;
            cooldownTimerBullet.Run();
            DisplayAttackShape(target.transform.position);
        }
    }
    public virtual void DisplayAttackShape(Vector2 direction)
    {
        Vector2 directionTarget = direction - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(directionTarget.y, directionTarget.x) * Mathf.Rad2Deg;
        

        if (AttackShape.GetComponent<MeleAttack>() is MeleAttack)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Debug.Log("AttackShape is a MeleAttack");
            var atkShape = GameObject.Instantiate(AttackShape, direction, Quaternion.identity);
            atkShape.transform.rotation = rotation;
        }
        else if (AttackShape.GetComponent<RangedAttack>() is RangedAttack)
        {
            Debug.Log("AttackShape is a Ranged");
            Quaternion rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
            //Behaviour of Ranged class write here
            //For eg
            //radius = gameobj.getComponent<CircleCollider2D>().radius
            //shoot from the current game object position
            var atkShape = GameObject.Instantiate(AttackShape, gameObject.transform.position, Quaternion.identity);
            //var radius = 10; // get circle collider here
            var rangedAttack = atkShape.GetComponent<RangedAttack>();
            if (rangedAttack != null)
            {
                rangedAttack.Range = GetComponent<CircleCollider2D>().radius; ;
            }
            Rigidbody2D rb2d = atkShape.GetComponent<Rigidbody2D>();
            rangedAttack.sourceDirection = transform.position;
            rb2d.AddForce(directionTarget.normalized*3, ForceMode2D.Impulse);
            atkShape.transform.rotation = rotation;
        }


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

