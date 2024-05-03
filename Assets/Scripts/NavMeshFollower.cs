using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private float maxDistance = 50f;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int MotionSpeed = Animator.StringToHash("MotionSpeed");

    private void Update()
    {
        if (TryGetComponent<Animator>(out var anim))
        {
            anim.SetFloat(MotionSpeed, 1.3f);
            anim.SetFloat(Speed, agent.velocity.magnitude);
        }

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