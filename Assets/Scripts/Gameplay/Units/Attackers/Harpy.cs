using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Harpy : Attacker
    {

        public static float damagePer = 0.4f;
        public static float hitpointsPer = 0.6f;
        public static float speedPer = 0.1f;

        public static float range = 3f;
        public static float selectedRange = 1.5f;
        public static float damage = 10f;

        public Harpy(int level) : base(level)
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
            BaseHitPoints = 50;
            BaseSpeed = 15;

            Initialize(damagePer, hitpointsPer, speedPer);
        }

    }
}
