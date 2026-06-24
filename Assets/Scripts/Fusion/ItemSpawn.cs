using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private List<GameObject> pref = new List<GameObject>();
    [SerializeField] private float delay;
    [SerializeField] private float timeToRepeat;
    [SerializeField] private int limit = 15;

    [Header("Area")]
    [SerializeField] private float radius;

    void Start()
    {
        InvokeRepeating("Spawn", delay,timeToRepeat);
    }

    void Spawn()
    {
        if(FusionManager.instance.activeItems.Count >= limit) return;
        int i = Random.Range(0, pref.Count);
        
        Vector3 pos = transform.position + Random.insideUnitSphere * radius;
        
        Instantiate(pref[i], pos, Quaternion.identity);
        
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
        // Gizmos.DrawWireCube(transform.position,new Vector3(largo*2, alto*2,1));
    }
}
