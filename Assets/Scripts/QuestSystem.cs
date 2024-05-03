using System.Linq;
using UnityEngine;

public static class QuestSystem
{
    public static void UpdateQuests(ItemType type)
    {
        var activeQuests = GameState.GetActiveQuests();
        foreach (var quest in activeQuests.ToList())
        {
            if (quest.Quest is CollectionQuest collectionQuest)
            {
                foreach (var requirement in collectionQuest.requirements)
                {
                    if (GameState.GetAllItems().TryGetValue(type, out var itemAmount))
                    {
                        if (itemAmount < requirement.amount)
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                
                GameState.MarkCompletable(collectionQuest);
            }
        }

        Object.FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
    }
}