using StarterAssets;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{
    [SerializeField] private float factor = 4f;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SlowDown();
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            SpeedUp();
        }
    }

    private void SpeedUp()
    {
        Time.timeScale *= factor;
        GetComponent<ThirdPersonController>().SprintSpeed /= factor / 2;
        GetComponent<ThirdPersonController>().MoveSpeed /= factor / 2;
    }

    private void SlowDown()
    {
        Time.timeScale /= factor;
        GetComponent<ThirdPersonController>().SprintSpeed *= factor / 2;
        GetComponent<ThirdPersonController>().MoveSpeed *= factor / 2;
    }
}