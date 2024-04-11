using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu]
public class CollectionQuest : ScriptableObject, IQuest
{
    public string displayName;
    [field: SerializeField] public ItemType Type { get; }
    [field: SerializeField] public uint Amount { get; } = 1;

    public string GetId()
    {
        return name;
    }

    public string GetDisplayName()
    {
        return displayName;
    }
}