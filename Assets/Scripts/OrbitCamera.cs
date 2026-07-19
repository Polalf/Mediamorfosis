using UnityEngine;



public class OrbitCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target; 

      
    [Header("Orbit")]
    public float distance = 10f;
    public float xSpeed = 120f;
    public float ySpeed = 120f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    [Header("Zoom")]
    public float zoomSpeed = 2f;
    public float minDistance = 2f;
    public float maxDistance = 20f;

    private float x = 0f;
    private float y = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.freezeRotation = true;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // ===== PC =====
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;

        // ===== MOBILE =====
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // ROTACIÓN (promedio del movimiento de ambos dedos)
            Vector2 avgDelta = (touch0.deltaPosition + touch1.deltaPosition) * 0.5f;

            x += avgDelta.x * xSpeed * 0.01f * Time.deltaTime;
            y -= avgDelta.y * ySpeed * 0.01f * Time.deltaTime;

            // ZOOM (pinch)
            Vector2 prevPos0 = touch0.position - touch0.deltaPosition;
            Vector2 prevPos1 = touch1.position - touch1.deltaPosition;

            float prevDistance = Vector2.Distance(prevPos0, prevPos1);
            float currentDistance = Vector2.Distance(touch0.position, touch1.position);

            float pinchDelta = currentDistance - prevDistance;

            distance -= pinchDelta * 0.01f * zoomSpeed;
        }

        y = ClampAngle(y, yMinLimit, yMaxLimit);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;

        return Mathf.Clamp(angle, min, max);
    }

  
}