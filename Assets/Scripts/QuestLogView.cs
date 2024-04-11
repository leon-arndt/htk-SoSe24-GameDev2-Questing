using UnityEngine;

public class QuestLogView : MonoBehaviour
{
    [SerializeField] private RectTransform questsHolder;
    [SerializeField] private QuestStatusView questViewPrefab;

    public void Refresh()
    {
        var activeQuests = GameState.GetActiveQuests();
        foreach (var quest in activeQuests)
        {
            var questView = Instantiate(questViewPrefab, questsHolder);
            questView.Set(quest);
        }
    }
}