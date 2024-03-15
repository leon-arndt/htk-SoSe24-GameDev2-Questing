using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Quit);
    }


    /// <summary>
    /// Cannot be tested in editor
    /// </summary>
    private void Quit()
    {
        Application.Quit();
    }
}
