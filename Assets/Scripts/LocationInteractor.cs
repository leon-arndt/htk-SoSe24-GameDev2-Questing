using Events;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

public class LocationInteractor : MonoBehaviour
{
    [CanBeNull] private IInteractable? _currentInteractable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentInteractable?.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            _currentInteractable = interactable;
            MessageBroker.Default.Publish(new InteractionPossibilitiesUpdated(_currentInteractable));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            if (_currentInteractable == interactable)
            {
                _currentInteractable = null;
                MessageBroker.Default.Publish(new InteractionPossibilitiesUpdated(_currentInteractable));
            }
        }
    }
}