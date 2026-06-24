using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip clip;
    
    public void Click()
    {
        audioManager.PlayAudio(clip);
    } 
}
