using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float Range { get; set; }
    public Vector2 sourceDirection;
    public Vector2 targetDirection;
    void Start()
    {

    }

    private void Update()
    {
        if (Vector2.Distance(sourceDirection, transform.position) - Range > 0||
            Vector2.Distance(transform.position, targetDirection)<0.1)
        {
            Destroy(gameObject);
        }
    }

}
