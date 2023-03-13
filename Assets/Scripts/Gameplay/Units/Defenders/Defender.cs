using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Defender : Unit
    {

        public Attacker currentTarget;
        public Defender(int level) : base(level)
        {
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

        }
        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("attackers") && currentTarget == null)
            {

                AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();

                //currentTarget = other.GetComponent<Attacker>();
                agent.SetTargetWhenStaying(other.gameObject);
                currentTarget = other.GetComponent<Attacker>();
                return;
            }

            // Check if the collider belongs to a Defender unit

            if (currentTarget != null && currentTarget.tag == "attackers")
            {
                if (Vector2.Distance(transform.position, currentTarget.transform.position) <= attackRange)
                {
                    AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();
                    if (HitPoints > 0)
                        agent.StopMoving();
                    gameObject.GetComponent<AgentMoventMent>().isMoving = false;
                }
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
