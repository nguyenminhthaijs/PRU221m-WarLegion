using UnityEngine;
using UnityEngine.AI;

public class AgentMoventMent : MonoBehaviour
{
    // Start is called before the first frame update


    Vector3 target;

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
        SetTargetPosition();
        SetAgentPosition();

    }
    void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(target.x + " " + target.y + " " + target.z);
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(target);
        }
    }
    public bool CheckIsMoving()
    {
        //Debug.Log(Vector2.Distance(new Vector2(target.x, target.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)));
        if (Vector2.Distance(new Vector2(target.x, target.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) <= 0.1f)
        {
            return false;
        }
        return true;
        return false;
    }
    void SetAgentPosition()
    {

    }
}
