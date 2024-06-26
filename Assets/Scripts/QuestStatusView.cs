using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// This is the status for a single quest: basically it's finishable or not finishable
/// </summary>
public class QuestStatusView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questStatusText;
    [SerializeField] private GameObject finishableIndicator;

    public void Set(IQuest quest)
    {
        questStatusText.text = quest.GetDisplayName();
        bool isCompletable = GameState.GetCompletableQuests().Any(x => x.Quest.GetId() == quest.GetId());
        finishableIndicator.SetActive(isCompletable);
    }
}