using UnityEngine;
using UnityEngine.AI;

public class MoveTemp : MonoBehaviour
{
    [SerializeField] Transform movePos;
    [SerializeField] NavMeshAgent navMeshAgent;
    public bool flagMove = false;
    public void Start()
    {
        flagMove = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.destination = movePos.position;
    }
    private void Update()
    {
        if (flagMove)
        {
            navMeshAgent.Stop();
        }
        else
        {
            navMeshAgent.Resume();
        }
        navMeshAgent.updateRotation = false;
        //navMeshAgent.destination = movePos.position;
    }
}
