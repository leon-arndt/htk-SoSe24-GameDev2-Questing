using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance;
    
    [SerializeField] private AudioSource _source;
    
    private void Awake()
    {
        if (Instance != null)
        {
            // we don't need two SoundPlayers
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public static void Play(AudioClip clip)
    {
        // TODO: this will call to FMOD later!
        Instance._source.PlayOneShot(clip); 
    }
}