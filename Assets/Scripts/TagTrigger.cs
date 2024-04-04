using UnityEngine;
using UnityEngine.Events;

public class TagTrigger : MonoBehaviour
{
    [SerializeField] private string tagToInteractWith;
    [SerializeField] private UnityEvent onEnter, onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToInteractWith))
        {
            onEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToInteractWith))
        {
            onExit?.Invoke();
        }
    }
}