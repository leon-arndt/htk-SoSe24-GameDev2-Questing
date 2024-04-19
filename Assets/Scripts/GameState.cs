using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private Dictionary<ItemType, uint> items = new();
    private List<IQuest> activeQuests = new();
    private List<IQuest> finishedQuests = new();
    
    public static void AddItem(ItemType type, uint amount)
    {
        var instance = FindObjectOfType<GameState>();
        if (!instance.items.TryAdd(type, amount))
        {
            instance.items[type] += amount;
        }
    }

    public static bool RemoveItem(ItemType type, uint amount)
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

    public static IReadOnlyDictionary<ItemType, uint> GetAllItems()
    {
        var instance = FindObjectOfType<GameState>();
        return instance.items;
    }
    
    public static void AddQuest(IQuest quest)
    {
        var instance = FindObjectOfType<GameState>();
        instance.activeQuests.Add(quest);
    }
    
    public static void RemoveQuest(IQuest quest)
    {
        var instance = FindObjectOfType<GameState>();
        instance.activeQuests.Remove(quest);
        instance.finishedQuests.Add(quest);
    }

    public static void FinishQuest(IQuest quest)
    {
        var instance = FindObjectOfType<GameState>();
        instance.finishedQuests.Add(quest);
    }
    
    public static IReadOnlyList<IQuest> GetFinishedQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance.finishedQuests;
    }
    
        public static IReadOnlyList<IQuest> GetActiveQuests()
    {
        var instance = FindObjectOfType<GameState>();
        return instance.activeQuests;
    }
}