using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Defender : Unit
    {

        private Attacker currentTarget;
        public Defender(int level) : base(level)
        {
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            // Check if the collider belongs to a Defender unit
            Attacker attacker = other.GetComponent<Attacker>();
            Debug.Log("test");

            if (attacker != null && (currentTarget == null || attacker == currentTarget))
            {
                currentTarget = attacker;
                Attack(attacker);
            }
        }

        public int UpGradedGold { get; set; }
    }
}
