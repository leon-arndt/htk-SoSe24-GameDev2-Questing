using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private Dictionary<ItemType, uint> items = new();
    private List<QuestState> questStates = new();

    public static void AddItem(ItemType type, uint amount)
    {
        var instance = FindObjectOfType<GameState>();
        if (!instance.items.TryAdd(type, amount))
        {
            instance.items[type] += amount;
        }
        
        QuestSystem.UpdateQuests(type);
    }

    public static bool TryRemoveItem(ItemType type, uint amount)
    {
        var instance = FindObjectOfType<GameState>();
        if (instance.items.TryGetValue(type, out var ownedAmount))
        {
            if (ownedAmount < amount)
            {
                return false;
            }

            instance.items[type] -= amount;
            return true;
        }

        return false;
    }

    public static bool HasEnoughItems(ItemType type, uint amount)
    {
        var instance = FindObjectOfType<GameState>();
        if (instance.items.TryGetValue(type, out var ownedAmount))
        {
            return ownedAmount >= amount;
        }

        return false;
    }

    public static IReadOnlyDictionary<ItemType, uint> GetAllItems()
    {
        var instance = FindObjectOfType<GameState>();
        return instance.items;
    }

    public static void StartQuest(IQuest quest)
    {
        var instance = FindObjectOfType<GameState>();
        
        if (instance.questStates.Any(q => q.Quest.GetId() == quest.GetId()))
        {
            Debug.LogWarning($"Quest{quest.GetId()} already started - not starting it again");
            return;
        }
        
        var state = new QuestState()
        {
            Quest = quest,
            Status = QuestStatus.Started,
        };
        instance.questStates.Add(state);
    }

    public static void RemoveQuest(string questId)
    {
        var instance = FindObjectOfType<GameState>();
        var match = instance.questStates.Find(q => q.Quest.GetId() == questId);
        instance.questStates.Remove(match);
    }

    public static void MarkCompletable(IQuest quest)
    {
        var instance = FindObjectOfType<GameState>();
        var match = instance.questStates.Find(q => q.Quest.GetId() == quest.GetId());
        match.Status = QuestStatus.Completable;
        var index = instance.questStates.FindIndex(q => q.Quest.GetId() == quest.GetId());
        if (index >= 0 && index < instance.questStates.Count)
        {
            instance.questStates[index] = match;
        }
    }
    
    public static IReadOnlyList<QuestState> GetCompletableQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance.questStates.Where(x => x.Status == QuestStatus.Completable).ToList();
    }

    public static IReadOnlyList<QuestState> GetCompletedQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance.questStates.Where(x => x.Status == QuestStatus.Completed).ToList();
    }

    public static IReadOnlyList<QuestState> GetActiveQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance.questStates;
    }
}

public struct QuestState
{
    public IQuest Quest;
    public QuestStatus Status;
};

public enum QuestStatus
{
    Started,
    Completable,
    Completed
}