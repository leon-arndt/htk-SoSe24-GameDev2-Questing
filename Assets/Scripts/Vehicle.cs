using UnityEngine;
using UnityEngine.AI;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 direction = Vector3.forward;
    
    [Range(1f, 5f)]
    [SerializeField]
    private float maxRandomSpeedMultiplier = 1.5f;

    private void Start()
    {
        agent.speed *= UnityEngine.Random.Range(1f, maxRandomSpeedMultiplier);
    }

    private void Update()
    {
        agent.SetDestination(transform.position + direction * 10f);
    }
}