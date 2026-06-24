using UnityEngine;
public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDie;
    void Start()
    {
        
        Destroy(gameObject,timeToDie);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime,Space.World);
    }

    public void SetTarget(Transform target)
    {
        transform.LookAt(target);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
