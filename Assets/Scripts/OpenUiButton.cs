using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenUiButton : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OpenUi);
    }

    private void OpenUi()
    {
        var uiRoot = FindObjectOfType<UiRoot>();
        if (uiRoot == null)
        {
            throw new Exception("No UiRoot found in scene");
        }
        
        Instantiate(screen, uiRoot.transform);
    }
}