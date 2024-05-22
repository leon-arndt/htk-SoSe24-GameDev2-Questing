using UnityEngine;

/// <summary>
/// Scriptable Objects are non-scene objects. They don't have positions, etc.
/// </summary>
[CreateAssetMenu]
public class ItemType : ScriptableObject
{
    public Sprite icon;
}
