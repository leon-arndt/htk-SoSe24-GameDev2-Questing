using UnityEngine;

public class QuestLogView : MonoBehaviour
{
    [SerializeField] private RectTransform questsHolder;
    [SerializeField] private QuestStatusView questViewPrefab;

    public void ShowActiveQuests()
    {
        // delete the outdated quests
        foreach (Transform child in questsHolder)
        {
            Destroy(child.gameObject);
        }

        // create + show the current quests
        var activeQuests = GameState.GetActiveQuests();
        foreach (var quest in activeQuests)
        {
            if (quest.Status == GameState.QuestStatus.Completed)
            {
                continue; // skip completed quests
            }

            if (quest.Quest.IsHidden())
            {
                continue; // skip hidden quests
            }

            var questView = Instantiate(questViewPrefab, questsHolder);
            questView.Set(quest.Quest);
        }
    }
}