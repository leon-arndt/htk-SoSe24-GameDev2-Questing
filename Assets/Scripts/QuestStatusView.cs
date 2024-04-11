using DefaultNamespace;
using TMPro;
using UnityEngine;

public class QuestStatusView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questStatusText;

    public void Set(IQuest questName)
    {
        questStatusText.text = questName.GetDisplayName();
    }
}