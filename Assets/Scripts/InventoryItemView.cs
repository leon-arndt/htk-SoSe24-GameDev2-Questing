using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI amountText;

    public void Set(ItemType type, uint amount)
    {
        amountText.text = amount.ToString();
        icon.sprite = type.icon;
    }
}