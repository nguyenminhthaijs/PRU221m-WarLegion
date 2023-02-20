using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Attacker : Unit
    {
        private Defender currentTarget;

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collider belongs to a Defender unit
            Defender defender = other.GetComponent<Defender>();
            if (defender != null && (currentTarget == null || defender == currentTarget))
            {
                // Attack the Defender
                currentTarget = defender;
                Attack(defender);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // Check if the collider belonged to the current target
            Defender defender = other.GetComponent<Defender>();
            if (defender != null && defender == currentTarget)
            {
                // Stop attacking the current target
                currentTarget = null;
            }
        }

        public override void Attack(Unit target)
        {
            // Only attack Defender units
            Defender defender = target as Defender;
            if (defender != null)
            {
                base.Attack(target);
            }
        }

        protected override void Die()
        {
            // If the current target dies, stop attacking it
            if (currentTarget != null && currentTarget.hitPoints <= 0)
            {
                currentTarget = null;
            }

            base.Die();
        }
        public int GainedGold { get; set; }
    }
}
