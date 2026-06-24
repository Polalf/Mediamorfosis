using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [Header("Configuración")]
    public float attractionRadius = 20f;
    public float attractionForce = 100f;
    public float destroyDistance = 1f;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);
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
        Gizmos.DrawWireSphere(transform.position, attractionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, destroyDistance);

    }
}