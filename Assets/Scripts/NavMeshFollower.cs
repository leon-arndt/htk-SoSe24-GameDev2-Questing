using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float minDistance = 5f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < minDistance)
        {
            agent.isStopped = true;
            return;
        }

        agent.isStopped = false;
        agent.SetDestination(target.position);
    }
}