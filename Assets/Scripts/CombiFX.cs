using UnityEngine;

public class CombiFX : MonoBehaviour
{
    [SerializeField] private float timeToDie;
     void Start()
    {
        Destroy(gameObject,timeToDie);
    }

}
