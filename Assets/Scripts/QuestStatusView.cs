using TMPro;
using UnityEngine;

public class QuestStatusView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questStatusText;

    public void Set(CollectionQuest questName)
    {
        questStatusText.text = questName.name;
    }
}