using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5;
    public float zoomSpeed = 2;
    public float minZoom = 5;
    public float maxZoom = 20;

    private float radius;
    private float rotationX;

    private void Start()
    {
        radius = minZoom;
        rotationX = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        radius -= Input.mouseScrollDelta.y * zoomSpeed;
        radius = Mathf.Clamp(radius, minZoom, maxZoom);
        rotationX = Input.GetAxis("Mouse X") * -rotationSpeed;
    }

    private void FixedUpdate()
    {
        transform.RotateAround(target.transform.position, Vector3.up, rotationX);
        transform.LookAt(target);
        var position = (transform.position - target.transform.position).normalized * radius + target.transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(position.x, 4, position.z), 0.1f);
    }
}
