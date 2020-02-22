using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathHoleEnemyDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            NavMeshAgent agent = other.gameObject.GetComponent<NavMeshAgent>();
            Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
            Patrol patrol = other.gameObject.GetComponent<Patrol>();
            // agent.isActiveAndEnabled = false;
            if(patrol != null)
            {
                patrol.enabled = false;
            }

            if (agent != null)
            {
                agent.isStopped = true;
                agent.enabled = false;
                body.velocity = Vector3.zero;
                body.isKinematic = false;
            }
            other.enabled = false;
            Destroy(other.gameObject, 4f);
        }
    }
}
