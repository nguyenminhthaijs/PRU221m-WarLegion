using UnityEngine;
using UnityEngine.AI;

public class AgentMoventMent : MonoBehaviour
{
    // Start is called before the first frame update


    Vector3 target;
    public bool isMoving = false;

    NavMeshAgent agent;
    void Awake()
    {
        target = gameObject.transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //SetTargetPosition();
        //SetAgentPosition();

        // Check if the agent has reached the target position
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    public void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(target.x + " " + target.y + " " + target.z);
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(target);

            isMoving = true;
        }
    }
    public void StopMoving()
    {
        if (gameObject != null)
            agent.isStopped = true;
    }
    public void ContinueMoving()
    {
        try
        {
            if (gameObject != null)
                agent.isStopped = false;
           // Debug.Log(gameObject);

        }
        catch
        {
         //   Debug.Log(gameObject);
        }

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
