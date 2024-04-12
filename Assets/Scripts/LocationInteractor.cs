using UnityEngine;

public class LocationInteractor : MonoBehaviour
{
    private IInteractable currentInteractable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable?.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            currentInteractable = interactable;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            if (currentInteractable == interactable)
            {
                currentInteractable = null;
            }
        }
    }
}