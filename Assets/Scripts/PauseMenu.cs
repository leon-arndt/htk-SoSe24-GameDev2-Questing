using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        pausePanel.SetActive(false);
        continueButton.onClick.AddListener(() => SetPausedStatus(false));
    }

    private void OnEnable()
    {
        continueButton.Select();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var wasPreviouslyPaused = pausePanel.activeSelf;
            SetPausedStatus(!wasPreviouslyPaused);
        }
    }

    private void SetPausedStatus(bool isPaused)
    {
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }
}