using UnityEngine;

/// <summary>
/// Choose appearance of one of the children
/// </summary>
public class RandomAppearance : MonoBehaviour
{
    private void Start()
    {
        var randomIndex = Random.Range(0, transform.childCount);
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == randomIndex);
        }
    }
}