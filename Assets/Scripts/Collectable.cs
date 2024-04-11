using DefaultNamespace;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    public ItemType type;
    public uint amount = 1;

    public void Interact()
    {
        Debug.Log("Collected" + name);
        
        GameState.AddItem(type, amount);

        UpdateQuests();
        Destroy(gameObject);
    }

    private void UpdateQuests()
    {
        var activeQuests = GameState.GetActiveQuests();
        foreach (var quest in activeQuests)
        {
            if (quest is CollectionQuest collectionQuest && collectionQuest.Type == type)
            {
                if (GameState.GetAllItems().TryGetValue(type, out var itemAmount))
                {
                    if (itemAmount >= collectionQuest.Amount)
                    {
                        GameState.FinishQuest(collectionQuest);
                    }
                }
            }
        }
    }
}