using UnityEngine;


public enum ItemType {Particula , Planeta , Nube , Estrella }

public class FusionItem : MonoBehaviour
{
    public ItemType itemType;

    public float radiusfactor = 1.5f;
    private float currentRadius;
    private bool fused = false;

    [SerializeField] private float minSize = 1f;
    [SerializeField] private float maxSize = 3.5f;
   
    [Header("Game Area")]
    [SerializeField] private float maxDistance = 65f;
    private void Start()
    {
        fused = false;
        float size = Random.Range(minSize,maxSize);
        // currentRadius = radius + size;
        currentRadius = size * radiusfactor;
        transform.localScale *=  size;
        FusionManager.instance.Register(this);
    }

    private void OnDestroy()
    {
        if (FusionManager.instance != null)FusionManager.instance.Unregister(this);
    }

    private void Update()
    {
        if (fused) return;

        CheckNearbyFusion();
        Checkdistance();
    }

    private void CheckNearbyFusion()
    {
        foreach (FusionItem other in FusionManager.instance.activeItems)
        {
            if (other == this) continue;
            if (other.fused) continue;

            float sqrDistance = (transform.position - other.transform.position).sqrMagnitude;

            float sqrRadius = currentRadius * currentRadius;


            if (sqrDistance <= sqrRadius)
            {
                if (FusionManager.instance.TryFusion(this, other, out GameObject result))
                {
                   
                    fused = true;
                    other.fused = true;

                    FusionManager.instance.ExecuteFusion(this,other);
                    
                    return;
                }
      
            }
        }
    }
    private void Checkdistance()
    {
        float dist = Vector3.Distance(transform.position, Vector3.zero);
        if(dist >= maxDistance) Destroy(gameObject);
    }
    void OnDrawGizmos()
    {
        if(itemType == ItemType.Particula)  Gizmos.color = Color.green;
        else if(itemType == ItemType.Planeta) Gizmos.color = Color.red;
        else if(itemType == ItemType.Nube) Gizmos.color = Color.blue;
        else  Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, currentRadius / 2);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusfactor / 2);

    }
}
