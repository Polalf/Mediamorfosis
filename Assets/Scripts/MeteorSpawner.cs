using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
   public GameObject prefab;

    [Header("Radios")]
    public float outerRadius = 10f;
    public float innerRadius = 3f;

    public float delayTime;
    public float spawnTime;

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
        meteor.GetComponent<Meteor>().SetTarget(transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, outerRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, innerRadius);
    }
}
