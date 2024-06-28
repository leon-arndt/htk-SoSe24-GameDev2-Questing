using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Useful to automatically select a UI element when the scene loads, e.g. buttons
/// </summary>
public class AutoSelect : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Selectable>().Select();
    }
}