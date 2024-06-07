using System.Linq;
using UnityEngine;

public static class QuestSystem
{
    public static void UpdateQuests()
    {
        var activeQuests = GameState.GetActiveQuests();
        foreach (var quest in activeQuests.ToList())
        {
            if (quest.Quest is CollectionQuest collectionQuest)
            {
                UpdateQuest(collectionQuest);
            }
        }

        Object.FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
    }

    private static void UpdateQuest(CollectionQuest collectionQuest)
    {
        foreach (var requirement in collectionQuest.requirements)
        {
            if (GameState.GetAllItems().TryGetValue(requirement.type, out var itemAmount))
            {
                if (itemAmount < requirement.amount)
                {
                    // not enough itemAmount
                    return;
                }
            }
            else
            {
                // don't have item at all
                return;
            }
        }

        GameState.MarkQuestCompletable(collectionQuest);
    }
}