using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private readonly Dictionary<ItemType, uint> _items = new();
    private readonly List<QuestState> _questStates = new();

    public static void AddItem(ItemType type, uint amount)
    {
        var instance = FindObjectOfType<GameState>();
        if (!instance._items.TryAdd(type, amount))
        {
            instance._items[type] += amount;
        }
        
        QuestSystem.UpdateQuests();
    }

    public static bool TryRemoveItem(ItemType type, uint amount)
    {
        var instance = FindObjectOfType<GameState>();
        if (instance._items.TryGetValue(type, out var ownedAmount))
        {
            if (ownedAmount < amount)
            {
                return false;
            }

            instance._items[type] -= amount;
            return true;
        }

        return false;
    }

    public static bool HasEnoughItems(ItemType type, uint amount)
    {
        var instance = FindObjectOfType<GameState>();
        if (instance._items.TryGetValue(type, out var ownedAmount))
        {
            return ownedAmount >= amount;
        }

        return false;
    }

    public static IReadOnlyDictionary<ItemType, uint> GetAllItems()
    {
        var instance = FindObjectOfType<GameState>();
        return instance._items;
    }

    public static void StartQuest(IQuest quest)
    {
        var instance = FindObjectOfType<GameState>();
        
        if (instance._questStates.Any(q => q.Quest.GetId() == quest.GetId()))
        {
            Debug.LogWarning($"Quest{quest.GetId()} already started - not starting it again");
            return;
        }
        
        var state = new QuestState()
        {
            Quest = quest,
            Status = QuestStatus.Started,
        };
        instance._questStates.Add(state);
        Debug.Log("Quest " + quest.GetId() + " started");
        QuestSystem.UpdateQuests();
    }

    public static void RemoveQuest(string questId)
    {
        var instance = FindObjectOfType<GameState>();
        var match = instance._questStates.Find(q => q.Quest.GetId() == questId);
        instance._questStates.Remove(match);
        Debug.Log("Quest " + questId + " removed");
    }

    public static void CompleteQuest(string questId)
    {
        var instance = FindObjectOfType<GameState>();
        var match = instance._questStates.Find(q => q.Quest.GetId() == questId);
        match.Status = QuestStatus.Completed;
        var index = instance._questStates.FindIndex(q => q.Quest.GetId() == questId);
        if (index >= 0 && index < instance._questStates.Count)
        {
            instance._questStates[index] = match;
        }
        
        if (match.Quest.CompleteScreenPrefab() != null)
        {
            var root = FindObjectOfType<UiRoot>().transform;
            Instantiate(match.Quest.CompleteScreenPrefab(), root);
        }
        Debug.Log("Quest " + questId + " completed");
    }

    public static void MarkQuestCompletable(IQuest quest)
    {
        var instance = FindObjectOfType<GameState>();
        var match = instance._questStates.Find(q => q.Quest.GetId() == quest.GetId());
        match.Status = QuestStatus.Completable;
        var index = instance._questStates.FindIndex(q => q.Quest.GetId() == quest.GetId());
        if (index >= 0 && index < instance._questStates.Count)
        {
            instance._questStates[index] = match;
            Debug.Log(quest.GetId() + " is now completable");
        }
    }
    
    public static IReadOnlyList<QuestState> GetCompletableQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance._questStates.Where(x => x.Status == QuestStatus.Completable).ToList();
    }

    public static IReadOnlyList<QuestState> GetCompletedQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance._questStates.Where(x => x.Status == QuestStatus.Completed).ToList();
    }

    public static IReadOnlyList<QuestState> GetActiveQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance._questStates;
    }
    
    public struct QuestState
    {
        public IQuest Quest;
        public QuestStatus Status;
    };
    
    public enum QuestStatus
    {
        Started = 0,
        Completable = 1,
        Completed = 2
    }
}