using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu]
public class CollectionQuest : ScriptableObject, IQuest
{
    [SerializeField] private ItemType type;
    [SerializeField] private uint amount = 1;
}