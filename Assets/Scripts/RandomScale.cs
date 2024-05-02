using UnityEngine;

public class RandomScale : MonoBehaviour
{
    [SerializeField] private float minScale = 0.8f;
    [SerializeField] private float maxScale = 1.3f;

    private void Awake()
    {
        var scale = Random.Range(minScale, maxScale);
        transform.localScale *= scale;
    }
}