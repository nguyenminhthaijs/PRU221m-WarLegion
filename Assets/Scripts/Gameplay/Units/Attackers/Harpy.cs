using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Harpy : Attacker
    {

        public static float damagePer = 0.4f;
        public static float hitpointsPer = 0.6f;
        public static float speedPer = 0.1f;
        public static AttackType attackType = AttackType.Mele;

        CircleCollider2D range;

        public Harpy(int level) : base(level)
        {
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            range = gameObject.GetComponent<CircleCollider2D>();
            cooldownTimerBullet = gameObject.AddComponent<Timer>();
            AttackRange = 1.5f;
            range.radius = AttackRange;

            BaseDamage = 10;
            BaseHitPoints = 50;
            BaseSpeed = 15;

            AttackType = AttackType;
            CoolDown = 1;

            Initialize(damagePer, hitpointsPer, speedPer);
        }

    }
}
