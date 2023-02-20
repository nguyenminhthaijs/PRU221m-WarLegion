namespace Assets.Scripts.Gameplay.Units
{
    public class HellBat : Attacker
    {
        public float damagePer = 0.4f;
        public float hitpointsPer = 0.6f;
        public float speedPer = 0.1f;
        public override void LevelUp()
        {
            base.LevelUp();
            damage = damage * damagePer;
            hitPoints = hitPoints * hitpointsPer;
            speed = speed * speedPer;
        }
    }
}
