using System;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryItemView itemPrefab;
    [SerializeField] private Transform itemHolder;
    private void Update()
    {
        var items = GameState.GetAllItems();

        foreach (Transform trans in itemHolder)
        {
            Destroy(trans.gameObject);
        }

        foreach (var item in items)
        {
            var spawnedItem = Instantiate(itemPrefab, itemHolder);
            spawnedItem.Set(item.Key, item.Value);
        }
    }
}