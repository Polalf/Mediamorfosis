#region 3D
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    private FusionItem selectedItem;

    [SerializeField] private float range = 100f; // distancia máxima del raycast
    [SerializeField] private Camera cam; // cámara principal

    private float objectDistance; // distancia inicial desde la cámara al objeto seleccionado

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        // Mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            TrySelectItem(ray);
        }

        // Touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = cam.ScreenPointToRay(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                TrySelectItem(ray);
            }
            else if (touch.phase == TouchPhase.Moved && selectedItem != null)
            {
                // Convertir posición de pantalla a mundo
                Vector3 screenPos = new Vector3(touch.position.x, touch.position.y, objectDistance);
                selectedItem.transform.position = cam.ScreenToWorldPoint(screenPos);
                
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                selectedItem = null;
            }
        }
    }

    void TrySelectItem(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            FusionItem item = hit.collider.GetComponent<FusionItem>();
            if (item != null)
            {
                selectedItem = item;
                // Guardamos la distancia desde la cámara para mover correctamente
                objectDistance = Vector3.Distance(cam.transform.position, selectedItem.transform.position);
                Debug.Log($"Seleccionado: {item.name}");
            }
        }
    }
}
#endregion
// #region  2D
// using UnityEngine;

// public class ItemSelectorXY : MonoBehaviour
// {
//     private FusionItem selectedItem;

//     [SerializeField] private Camera cam; // cámara principal
//     [SerializeField] private float range = 100f; // distancia máxima del raycast

//     private float fixedZ; // Z fijo del objeto en el mundo

//     void Start()
//     {
//         if (cam == null)
//             cam = Camera.main;
//     }

//     void Update()
//     {
//         // Mouse click
//         if (Input.GetMouseButtonDown(0))
//         {
//             Ray ray = cam.ScreenPointToRay(Input.mousePosition);
//             TrySelectItem(ray);
//         }

//         if (Input.GetMouseButton(0) && selectedItem != null)
//         {
//             MoveSelectedToMouse(Input.mousePosition);
//         }

//         if (Input.GetMouseButtonUp(0))
//         {
//             Deselect();
//         }

//         // Touch
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);

//             if (touch.phase == TouchPhase.Began)
//             {
//                 Ray ray = cam.ScreenPointToRay(touch.position);
//                 TrySelectItem(ray);
//             }
//             else if (touch.phase == TouchPhase.Moved && selectedItem != null)
//             {
//                 MoveSelectedToMouse(touch.position);
//             }
//             else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
//             {
//                 Deselect();
//             }
//         }
//     }

//     void TrySelectItem(Ray ray)
//     {
//         if (Physics.Raycast(ray, out RaycastHit hit, range))
//         {
//             FusionItem item = hit.collider.GetComponent<FusionItem>();
//             if (item != null)
//             {
//                 selectedItem = item;
//                 fixedZ = selectedItem.transform.position.z; // Fijamos Z actual
//                 Debug.Log($"Seleccionado: {item.name}");
//             }
//         }
//     }

//     void MoveSelectedToMouse(Vector3 screenPos)
//     {
//         // Convertimos la posición del mouse/touch a mundo en el plano XY
//         Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, cam.WorldToScreenPoint(new Vector3(0,0,fixedZ)).z));
//         selectedItem.transform.position = new Vector3(worldPos.x, worldPos.y, fixedZ);
//     }

//     void Deselect()
//     {
//         selectedItem = null;
//     }
// }
// #endregion