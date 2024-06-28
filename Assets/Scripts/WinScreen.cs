using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    
    private void Awake()
    {
       menuButton.onClick.AddListener(() =>
       {
           // Load the main menu scene
           SceneManager.LoadScene(0);
       });
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            menuButton.Select();
        }
    }
}