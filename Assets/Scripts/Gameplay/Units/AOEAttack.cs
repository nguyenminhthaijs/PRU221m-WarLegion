using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AOEAttack : MonoBehaviour
{
    // Start is called before the first frame update

    Timer existTime;
    float damage = 10f;
 

    void Start()
    {
        Debug.Log("attack");
        existTime = gameObject.AddComponent<Timer>();
        existTime.Duration = 2f;
        existTime.Run();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Collider[] colliders = Physics.OverlapSphere(hit.point, damage);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("defenders"))
                {
                    Unit enemyHealth = collider.GetComponent<Unit>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damage);
                    }
                }
            }
           
        }
        if (existTime.Finished)
        {
            Destroy(gameObject);
        }
    }
}
