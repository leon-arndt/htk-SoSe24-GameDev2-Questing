using UnityEngine;

public class StoryNpc : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset story;


    public void Interact()
    {
        FindObjectOfType<StoryView>(true).StartStory(story);
    }
}