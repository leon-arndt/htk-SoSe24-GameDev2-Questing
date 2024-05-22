using UnityEngine;

public class Openable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ItemType _requiredItem;
    [SerializeField] private ItemType _givenItem;
    [SerializeField] private uint _givenAmount = 1;
    [SerializeField] private uint _requiredAmount = 1;
    [SerializeField] private bool _shouldConsume = true;
    private bool _isOpen;

    public void Interact()
    {
        if (_isOpen)
        {
            return;
        }

        if (_shouldConsume)
        {
            // 🍏🍏🍽️🍽️
            if (GameState.TryRemoveItem(_requiredItem, _requiredAmount))
            {
                Open();
            }
        }
        else
        {
            // 🔑🔑🗝️🔐
            if (GameState.HasEnoughItems(_requiredItem, _requiredAmount))
            {
                Open();
            }
        }
    }

    private void Open()
    {
        _isOpen = true;
        if (_animator != null)
        {
            _animator.SetBool("isOpen", true);
        }
        GameState.AddItem(_givenItem, _givenAmount);
        Debug.Log("Opened:" + gameObject.name);
    }
}