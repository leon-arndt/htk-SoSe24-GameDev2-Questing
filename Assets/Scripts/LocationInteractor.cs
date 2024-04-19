using System;
using Events;
using UniRx;
using UnityEngine;

public class LocationInteractor : MonoBehaviour
{
    private IInteractable currentInteractable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            try
            {
                // try using the interactable
                currentInteractable.Interact();
            }
            catch (Exception e)
            {
                // sometimes the interactable is null (if it was destroyed)
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            currentInteractable = interactable;
            MessageBroker.Default.Publish(new InteractionPossibilitiesUpdated(currentInteractable));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            if (currentInteractable == interactable)
            {
                currentInteractable = null;
                MessageBroker.Default.Publish(new InteractionPossibilitiesUpdated(currentInteractable));
            }
        }
    }
}