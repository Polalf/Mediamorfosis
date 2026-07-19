using UnityEngine;
public class MeteorSpawner : MonoBehaviour
{
   public GameObject prefab;

    [Header("Radios")]
    public float outerRadius = 10f;
    public float innerRadius = 3f;
    public float targetRadius = 3f;

    public float delayTime;
    public float spawnTime;

    private Vector3 target;
    private void Start()
    {
       InvokeRepeating("Spawn",delayTime,spawnTime);
    }

    void Spawn()
    {
        Vector3 direction = Random.onUnitSphere;
        float distance = Random.Range(innerRadius, outerRadius);

        Vector3 spawnPosition = transform.position + direction * distance;

        GameObject meteor = Instantiate(prefab, spawnPosition, Quaternion.identity);
        target = Random.insideUnitSphere * targetRadius;
        meteor.GetComponent<Meteor>().SetTarget(target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, outerRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, innerRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetRadius);

        Gizmos.DrawSphere(target, .5f);
    }
}
