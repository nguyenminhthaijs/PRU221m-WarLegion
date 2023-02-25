using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float Range { get; set; }
    public Vector2 sourceDirection;
    void Start()
    {

    }

    private void Update()
    {
        if (Vector2.Distance(sourceDirection, transform.position) - Range > 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag != "attackers")
        {
            Destroy(gameObject);
        }
    }
}
