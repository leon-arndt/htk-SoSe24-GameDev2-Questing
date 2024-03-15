using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOpenerButton : MonoBehaviour
{
    [SerializeField]
    private int buildIndex;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
