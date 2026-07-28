using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private Transform planetTransform; 
    [SerializeField] private MeshRenderer planetRenderer;
    
    [SerializeField] private Vector3 rotAngle;
    [SerializeField] private float rotDir;
    [SerializeField] private Transform ringTransform; 
    [SerializeField] private MeshRenderer ringRenderer;
    [SerializeField] private List<Material> surfaces = new List<Material>();
    [SerializeField] private List<Material> rings = new List<Material>();

    void Start()
    {
        int s = Random.Range(0,surfaces.Count);
        planetRenderer.material = surfaces[s];

        float x = Random.Range(-rotAngle.x, rotAngle.x);
        float y = Random.Range(-rotAngle.y, rotAngle.y);
        float z = Random.Range(-rotAngle.z, rotAngle.z);
        planetTransform.rotation = Quaternion.Euler(new Vector3(x,y,z));
        
        int r = Random.Range(0,rings.Count);
        ringRenderer.material = rings[r];
        if(r == 0) ringTransform.gameObject.SetActive(false);

        rotDir = Random.Range(-1f,1f);
    }
    void Update()
    {
        planetTransform.Rotate(new Vector3(0,rotDir,0), Space.Self);
    }
}
