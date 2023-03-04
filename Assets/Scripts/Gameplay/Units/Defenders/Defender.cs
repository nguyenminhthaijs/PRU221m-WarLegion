using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Defender : Unit
    {

        public Attacker currentTarget;
        public Defender(int level) : base(level)
        {
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            // Check if the collider belongs to a Defender unit

            if (currentTarget != null && currentTarget.tag == "attackers")
            {
                AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();
                agent.StopMoving();
                gameObject.GetComponent<AgentMoventMent>().isMoving = false;
            }
            else
            {
                AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();
                if (HitPoints > 0)
                    agent.ContinueMoving();
            }
            Attacker attacker = other.GetComponent<Attacker>();
            if (attacker != null && (currentTarget == null || attacker == currentTarget))
            {
                //currentTarget = attacker;
                // đến tầm mới bắn
                if (Vector2.Distance(transform.position, attacker.transform.position) <= attackRange)
                {
                    Attack(attacker);
                }
            }
        }

        public int UpGradedGold { get; set; }
    }
}
