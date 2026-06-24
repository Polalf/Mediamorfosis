using UnityEngine;

public class AudioManager : Singleton<MonoBehaviour>
{
    [SerializeField] AudioSource audioSource;

    protected override bool persistent => false;

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
