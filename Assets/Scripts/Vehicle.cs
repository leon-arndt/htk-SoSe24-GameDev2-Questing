using UnityEngine;
using UnityEngine.AI;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 direction = Vector3.forward;

    [Range(1f, 5f)] [SerializeField] private float maxRandomSpeedMultiplier = 1.5f;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int MotionSpeed = Animator.StringToHash("MotionSpeed");

    private void Start()
    {
        var speed = UnityEngine.Random.Range(1f, maxRandomSpeedMultiplier);
        agent.speed *= speed;
        if (TryGetComponent<Animator>(out var anim))
        {
            anim.SetFloat(MotionSpeed, 1.3f);
            anim.SetFloat(Speed, speed * 1.3f);
        }

        Destroy(gameObject, 50f);

        if (Random.value > 0.5f)
        {
            direction *= -1f;
        }
    }

    private void Update()
    {
        agent.SetDestination(transform.position + direction * 10f);
    }
}