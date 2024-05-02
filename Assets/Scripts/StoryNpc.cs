using UnityEngine;

public class StoryNpc : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset story;

    private void Start()
    {
        var closeupCamera = GetComponentInChildren<Camera>(true);
        if (closeupCamera != null)
        {
            closeupCamera.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        var closeupCamera = GetComponentInChildren<Camera>(true);
        if (closeupCamera != null)
        {
            closeupCamera.gameObject.SetActive(true);
        }
        var storyView = FindObjectOfType<StoryView>(true);
        if (storyView.isActiveAndEnabled)
        {
            return;
        }

        storyView.StartStory(story, OnFinished);
    }

    private void OnFinished()
    {
        var closeupCamera = GetComponentInChildren<Camera>(true);
        if (closeupCamera != null)
        {
            closeupCamera.gameObject.SetActive(false);
        }
    }
}