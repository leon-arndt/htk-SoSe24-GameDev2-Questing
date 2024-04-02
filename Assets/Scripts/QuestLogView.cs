using System.Collections.Generic;
using UnityEngine;

public class QuestLogView : MonoBehaviour
{
    [SerializeField] private List<CollectionQuest> quests;
    private List<CollectionQuest> activeQuests = new List<CollectionQuest>();
    [SerializeField] private RectTransform questsHolder;
    [SerializeField] private QuestStatusView questViewPrefab;

    public void Add(string questId)
    {
        var questData = quests.Find(quest => quest.name == questId);
        activeQuests.Add(questData);
        var questView = Instantiate(questViewPrefab, questsHolder);
        questView.Set(questData);
    }

    private void Update()
    {
        // update all quests
    }
}