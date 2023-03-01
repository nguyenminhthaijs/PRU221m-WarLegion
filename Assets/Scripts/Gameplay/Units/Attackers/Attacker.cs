using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Attacker : Unit
    {
        private Defender currentTarget;

        public Attacker(int level) : base(level)
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {           
            // Check if the collider belongs to a Defender unit

            if (currentTarget != null && currentTarget.tag == "defenders")
            {
                Debug.Log("Ok");
                AgentMoventMentMonster agent = gameObject.GetComponent<AgentMoventMentMonster>();
                // trien khai cach 1 : target luon la currentTarget ( Cham thang nao thi duoi theo danh cho chet bang dc )
                agent.SetTargetPosition(currentTarget.gameObject);
                // trien khai cach 2 : trong combat cham thang nao thi danh thang do
                //agent.SetTargetPosition(other.gameObject);
                //currentTarget = other.gameObject.GetComponent<Defender>();
                agent.isAccessMovingTower = false;
                // Đủ tầm đánh mới Stop 
                if (Vector2.Distance(transform.position, currentTarget.transform.position) <= attackRange)
                {
                    Debug.Log("Da Dung");
                    agent.StopMoving();
                }
            }
            else
            {
                // Đánh chết defenders thì đi tiếp đến trụ 
                AgentMoventMentMonster agent = gameObject.GetComponent<AgentMoventMentMonster>();
                agent.isAccessMovingTower = true;
                agent.ContinueMoving();
            }
            // Check if the collider belongs to a Defender unit
            Defender defender = other.GetComponent<Defender>();
            if (other.GetComponent<Defender>() is Defender)
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
            if (other.GetComponent<Defender>() is Defender)
            {
                if (defender != null && defender == currentTarget)
                {
                    // Stop attacking the current target
                    Debug.Log("Out");
                    // Neu Defender move khoi Attracker thi set lai target den vi tri Defender vua move
                    AgentMoventMentMonster agent = gameObject.GetComponent<AgentMoventMentMonster>();
                    agent.SetTargetPosition(currentTarget.gameObject);
                    agent.ContinueMoving();
                    agent.isAccessMovingTower = false;
                    //currentTarget = null;
                }
            }
        }

        public override void Attack(Unit target)
        {
            // Only attack Defender units
            Defender defender = target as Defender;
            if (defender != null)
            {
                //Debug.Log(target);
                base.Attack(target);
            }
        }

        protected override void Die()
        {
            // If the current target dies, stop attacking it
            if (currentTarget != null && currentTarget.HitPoints <= 0)
            {
                currentTarget = null;
            }

            base.Die();
        }
        public int GainedGold { get; set; }
    }
}
