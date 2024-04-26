using System.Linq;
using UnityEngine;

public static class QuestSystem
{
    public static void UpdateQuests(ItemType type)
    {
        var activeQuests = GameState.GetActiveQuests();
        foreach (var quest in activeQuests.ToList())
        {
            if (quest.Quest is CollectionQuest collectionQuest && collectionQuest.type == type)
            {
                if (GameState.GetAllItems().TryGetValue(type, out var itemAmount))
                {
                    if (itemAmount >= collectionQuest.amount)
                    {
                        GameState.MarkCompletable(collectionQuest);
                    }
                }
            }   
        }
        
        Object.FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
    }
}