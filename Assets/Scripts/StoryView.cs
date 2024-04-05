using System;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StoryView : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;
    private Story story;

    [SerializeField] private RectTransform choiceHolder;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Button buttonPrefab;

    private void Awake()
    {
        DestroyChildren();
        gameObject.SetActive(false);
    }

    public void StartStory(TextAsset textAsset)
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        gameObject.SetActive(true);
        story = new Story(textAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        story.BindExternalFunction ("addQuest", (string questName) => {
            FindObjectOfType<QuestLogView>().Add(questName);
        });
        
        RefreshView();
    }

    private void RefreshView()
    {
        DestroyChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
        }

        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate { OnClickChoiceButton(choice); });
            }
        }
        else
        {
            Button choice = CreateChoiceView("Continue");
            choice.onClick.AddListener(() =>
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                gameObject.SetActive(false);
                FindObjectOfType<PlayerInput>().enabled = true;
            });
        }
    }

    private void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    private void CreateContentView(string text)
    {
        string[] parts = text.Split(':');
        if (parts.Length >= 2)
        {
            speakerName.text = parts[0];
            storyText.text = parts[1];
        }
        else
        {
            speakerName.text = string.Empty;
            storyText.text = text;
        }
    }

    private Button CreateChoiceView(string text)
    {
        var choice = Instantiate(buttonPrefab, choiceHolder.transform, false);

        var choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        return choice;
    }

    private void DestroyChildren()
    {
        int childCount = choiceHolder.transform.childCount;

        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }
    }
}