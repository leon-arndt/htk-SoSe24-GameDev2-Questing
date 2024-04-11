using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu]
public class CollectionQuest : ScriptableObject, IQuest
{
    public string displayName;
    [SerializeField] private ItemType type;
    [SerializeField] private uint amount = 1;
}