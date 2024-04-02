using UnityEngine;

public class LocationInteractor : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interact();
        }
    }
}