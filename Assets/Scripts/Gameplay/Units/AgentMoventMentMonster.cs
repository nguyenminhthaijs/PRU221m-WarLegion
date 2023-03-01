using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Gameplay.Units
{
    public class AgentMoventMentMonster : MonoBehaviour
    {
        Vector3 target;
        public bool isMoving = false;

        public bool isAccessMovingTower = true; 
        // Chi co 1 tru thi khai bao day luon 
        public GameObject tower; 

        NavMeshAgent agent;
        void Awake()
        {
            target = gameObject.transform.position;
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.SetDestination(tower.transform.position);
            isAccessMovingTower = true;
        }

        // Update is called once per frame
        void Update()
        {
            // Cu den muc tieu thi set target den tower
            // Truong hop den roi thi khong phai set nua
            if (Vector2.Distance(gameObject.transform.position, tower.transform.position) > 0.1f && isAccessMovingTower == true)
            {
                Debug.Log(Vector2.Distance(gameObject.transform.position, tower.transform.position));
                agent.SetDestination(tower.transform.position);
                Debug.Log("Target tower");
            }
            else
            {
                isMoving = false;
            }
        }
        public void SetTargetPosition(GameObject t)
        {
            Transform transform = t.transform; 
            agent.SetDestination(transform.position);
            isMoving = true;
        }
        public void StopMoving()
        {
            agent.isStopped = true;
        }
        public void ContinueMoving()
        {
            agent.isStopped = false;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("Find enemies");
        }
        public bool CheckIsMoving()
        {
            return isMoving;
        }
        void SetAgentPosition()
        {

        }
    }
}
