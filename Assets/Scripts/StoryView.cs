using System;
using System.Linq;
using DefaultNamespace;
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
    [SerializeField] private QuestsConfig questConfig;

    private void Awake()
    {
        DestroyOldChoices();
        gameObject.SetActive(false);
    }

    public void StartStory(TextAsset textAsset)
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        gameObject.SetActive(true);
        story = new Story(textAsset.text);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        ShowStory();
    }
    
    private void CloseStory()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        FindObjectOfType<PlayerInput>().enabled = true;
    }

    private void ShowStory()
    {
        DestroyOldChoices();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
            // HandleTags(); //TODO: tags kommen später
        }

        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener( () => OnClickChoiceButton(choice));
            }
        }
        else
        {
            Button choice = CreateChoiceView("Continue");
            choice.onClick.AddListener(CloseStory);
        }
    }

    private void HandleTags()
    {
        if (story.currentTags.Count <= 0)
        {
            return;
        }

        foreach (var currentTag in story.currentTags)
        {
            if (currentTag.Contains("addQuest"))
            {
                var questName = currentTag.Split(' ')[1];
                var quest = questConfig.quests.First(q => q.GetId() == questName);
                GameState.AddQuest(quest);
                FindObjectOfType<QuestLogView>().ShowActiveQuests();
            }

            if (currentTag.Contains("removeQuest"))
            {
                var questName = currentTag.Split(' ')[1];
                var quests = GameState.GetActiveQuests();
                var quest = quests.First(q => q.GetId() == questName);
                GameState.RemoveQuest(quest);
                FindObjectOfType<QuestLogView>().ShowActiveQuests();
            }
        }
    }

    private void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        ShowStory();
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

    private void DestroyOldChoices()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    private Button CreateChoiceView(string text)
    {
        var choice = Instantiate(buttonPrefab, choiceHolder.transform, false);

        var choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        return choice;
    }
}