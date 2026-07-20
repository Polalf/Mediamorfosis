using UnityEngine;
public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDie;
    void Start()
    {
        
        Destroy(gameObject,timeToDie);
    }


    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime,Space.World);
    }

    public void SetTarget(Vector3 target)
    {
        transform.LookAt(target);
    }
    void OnCollisionEnter(Collision collision)
    {
        
        CameraShake.instance.ShakeCam();
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
