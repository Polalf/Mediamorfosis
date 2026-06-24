using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;   

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] string parameterName = "Music";//cambiar el nombre del parametro, para usar el codigo para musica y sfx
    [SerializeField] string saveName = "MusicVolume";//nombre para el playerPrefs que guardara la configuracion de audio

    private void Start()
    {
        if (PlayerPrefs.HasKey(saveName))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(saveName, volume);
    }

    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(saveName);
        SetVolume();
    }
}