using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] public Transform movePos;
    [SerializeField] public NavMeshAgent navMeshAgent;
    private void Update()
    {
        navMeshAgent.destination = movePos.position;
    }
}
