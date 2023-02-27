using Assets.Scripts.Gameplay.Units;

public class Archery : Defender
{
    public static float damagePer = 0.55f;
    public static float hitpointsPer = 0.45f;
    public static float speedPer = 0.1f;

    public static float range = 5f;
    public static float selectedRange = 1.5f;
    public static float damage = 10f;


    public Archery(int level) : base(level)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate<GameObject>(atkShape, transform.position, Quaternion.identity);
        AttackRange = range;
        SelectedRange = selectedRange;

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
