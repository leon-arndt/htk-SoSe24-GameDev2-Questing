using Events;
using UniRx;
using UnityEngine;

/// <summary>
/// Define a special area in the game world. Similar to games like Skyrim which display the name of the area when the player enters it.
/// </summary>
public class SpecialArea : MonoBehaviour
{
    [SerializeField] private string displayName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessageBroker.Default.Publish(new AreaEntered(displayName));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessageBroker.Default.Publish(new AreaLeft(displayName));
        }
    }
}