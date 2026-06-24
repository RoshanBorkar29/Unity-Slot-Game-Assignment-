using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip spinClip;

    private void Awake()
    {
        // Simple singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySpinSound()
    {
        sfxSource.PlayOneShot(spinClip);
    }

    public void PlayWinSound()
    {
        sfxSource.PlayOneShot(winClip);
    }

    public void PlayLoseSound()
    {
        sfxSource.PlayOneShot(loseClip);
    }
}