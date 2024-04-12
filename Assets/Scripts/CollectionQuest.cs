using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu]
public class CollectionQuest : ScriptableObject, IQuest
{
    public string displayName;
    public ItemType type;
    public uint amount = 1;

    public string GetId()
    {
        return name;
    }

    public string GetDisplayName()
    {
        return displayName;
    }
}