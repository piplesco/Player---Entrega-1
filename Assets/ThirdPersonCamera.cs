using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float sensibilidadX = 4f;
    public float sensibilidadY = 2f;
    public float minY = -20f;
    public float maxY = 60f;
    public float lerpValue = 0.1f;

    private float rotX;
    private float rotY;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotX = angles.y;
        rotY = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        rotX += Input.GetAxis("Mouse X") * sensibilidadX;
        rotY -= Input.GetAxis("Mouse Y") * sensibilidadY;
        rotY = Mathf.Clamp(rotY, minY, maxY);

        Quaternion rotation = Quaternion.Euler(rotY, rotX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpValue);

        transform.LookAt(target.position + Vector3.up * offset.y);
    }
}


