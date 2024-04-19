using Events;
using TMPro;
using UniRx;
using UnityEngine;

public class InteractionHintView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hintText;

    private void Awake()
    {
        hintText.text = string.Empty;

        MessageBroker.Default.Receive<InteractionPossibilitiesUpdated>()
            .Subscribe(x => UpdateText(x.intearctable))
            .AddTo(this);
    }

    private void UpdateText(IInteractable target)
    {
        if (target == null)
        {
            hintText.text = string.Empty;
        }
        else
        {
            hintText.text = "Press E to interact";
        }
    }
}