using UnityEngine;
using UnityEngine.Events;

public class WorldButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent _onInteract;

    public void Interact()
    {
        _onInteract?.Invoke();
    }
}