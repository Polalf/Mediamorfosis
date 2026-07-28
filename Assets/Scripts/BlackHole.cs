using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [Header("Spawn")]
    public float minSize = 1;
    public float maxSize = 3;
    [Header("Configuración")]
    public float attractionRadius = 20f;
    private float currentRadius;
    public float attractionForce = 100f;
    public float destroyDistance = 1f;
    void Start()
    {
        float size = Random.Range(minSize,maxSize);
        transform.localScale = Vector3.one * size;
        currentRadius = attractionRadius + size;
    }
    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, currentRadius);
        if(colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    Vector3 force = transform.position - rb.position;
                    float distance = force.magnitude;
                    rb.AddForce(force * attractionForce * Time.deltaTime);
                    
                    if(distance <= destroyDistance)
                    {
                        Destroy(colliders[i].gameObject);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, currentRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, destroyDistance);

    }
}