namespace Assets.Scripts.Gameplay.Units
{
    public class HellBat : Attacker
    {

        public float damagePer = 0.4f;
        public float hitpointsPer = 0.6f;
        public float speedPer = 0.1f;


        public HellBat(int level) : base(level)
        {
            BaseDamage = 10;
            BaseHitPoints = 50;
            BaseSpeed = 15;
            Initialize(damagePer, hitpointsPer, speedPer);
        }
    }
}
