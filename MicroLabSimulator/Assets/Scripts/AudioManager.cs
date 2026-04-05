using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource source;

    public AudioClip clickSound;
    public AudioClip successSound;
    public AudioClip errorSound;

    void Awake()
    {
        instance = this;
    }

    public void PlayClick()
    {
        source.PlayOneShot(clickSound);
    }

    public void PlaySuccess()
    {
        source.PlayOneShot(successSound);
    }

    public void PlayError()
    {
        source.PlayOneShot(errorSound);
    }
}