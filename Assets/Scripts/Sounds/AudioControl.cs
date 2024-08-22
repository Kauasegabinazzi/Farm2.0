using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip otherMusic;
    private AudioManager manager;

    // Update is called once per frame
    void Start()
    {
        manager = FindAnyObjectByType<AudioManager>();

        manager.PlayBGM(otherMusic);
    }
}
