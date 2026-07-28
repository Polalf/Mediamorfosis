using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private List<GameObject> prefs = new List<GameObject>();
    [SerializeField] private float delay;
    [SerializeField] private float timeToRepeat;
    [SerializeField] private int limit = 15;

    [Header("Area")]
    [SerializeField] private float radius = 40;
    [SerializeField] private float blackhole = 50;

    [Header("Blackhole")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int minCount = 2;
    [SerializeField] private int maxCount = 5;
    void Start()
    {
        InvokeRepeating("Spawn", delay,timeToRepeat);
        int x = Random.Range(minCount, maxCount+1);

        for (int i = 0; i < x; i++)
        {
            Vector3 pos = transform.position + Random.insideUnitSphere * blackhole;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }

    void Spawn()
    {
        if(FusionManager.instance.activeItems.Count >= limit) return;
        int i = Random.Range(0, prefs.Count);
        
        Vector3 pos = transform.position + Random.insideUnitSphere * radius;
        
        Instantiate(prefs[i], pos, Quaternion.identity);
        
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
        // Gizmos.DrawWireCube(transform.position,new Vector3(largo*2, alto*2,1));
    }
}
