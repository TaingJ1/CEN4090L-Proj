using UnityEngine;

public class TitleAudioManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip Clip;

    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
        audioSource.clip = Clip;
        audioSource.Play();
    }
}
