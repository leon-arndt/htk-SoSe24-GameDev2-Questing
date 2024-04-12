using UnityEngine;

public class LocationInteractor : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }
    }
}