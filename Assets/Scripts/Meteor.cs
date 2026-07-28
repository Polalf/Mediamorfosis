using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDie;
    [SerializeField] private GameObject collisioneffect;
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
        Instantiate(collisioneffect, transform.position, Quaternion.identity);
        CameraShake.instance.ShakeCam();
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
