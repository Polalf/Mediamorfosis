using UnityEngine;
using Unity.Cinemachine;
public class CameraShake : Singleton<CameraShake>
{
    protected override bool persistent =>  false;

    [Header("Shake")]
    
    [SerializeField] private CinemachineBasicMultiChannelPerlin perlin;
    [SerializeField] public  float shakeTime;
    [SerializeField] private float shakeIntensity;

    void Start()
    {
        perlin = GetComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.AmplitudeGain = 0;
    }
    public void ShakeCam()
    {
        perlin.AmplitudeGain = shakeIntensity;
        
        Invoke("StopShaking", shakeTime);

    }
    void StopShaking()
    {
        perlin.AmplitudeGain = 0;
    }
}
