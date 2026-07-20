using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip fx;
    [SerializeField] private float lifeTime = 2f;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(fx);
        Destroy(gameObject, lifeTime);
    }

  
}
