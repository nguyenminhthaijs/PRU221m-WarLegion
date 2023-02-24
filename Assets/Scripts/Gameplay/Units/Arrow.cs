using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    public GameObject archery;
    // Update is called once per frame
    private CircleCollider2D collider;
    void Start()
    {
        collider = archery.GetComponent<CircleCollider2D>();

    }

    private void Update()
    {
        if (Vector2.Distance(archery.transform.position, transform.position) - collider.radius > 0)
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
