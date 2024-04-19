using UnityEngine;

public class Openable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _openBool = "Open";
    [SerializeField] private ItemType _requiredItem;
    [SerializeField] private uint _requiredAmount = 1;
    
    private bool _opened;

    public void Interact()
    {
        if (_opened)
        {
            return;
        }

        if (GameState.RemoveItem(_requiredItem, _requiredAmount))
        {
            Open();
        }
    }

    private void Open()
    {
        _opened = true;
        _animator.SetBool(_openBool, true);
    }
}