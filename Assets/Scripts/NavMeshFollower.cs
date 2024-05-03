using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private float maxDistance = 50f;

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance < minDistance)
        {
            agent.isStopped = true;
            return;
        }
        
        if (distance > maxDistance)
        {
            agent.isStopped = true;
        }

        agent.isStopped = false;
        agent.SetDestination(target.position);
    }
}