using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float _yaw = 0;
    private float _pitch = 0;
    private bool _lookEnabled = false;

    public float BaseSpeed = 5;
    public float RunSpeed = 10;

    private void Awake()
    {
        _yaw = transform.rotation.eulerAngles.y;
        _pitch = transform.rotation.eulerAngles.x;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                _lookEnabled = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _lookEnabled = false;
            }
        }

        if (_lookEnabled)
        {
            _yaw += Input.GetAxis("Mouse X");
            _pitch -= Input.GetAxis("Mouse Y");
            _pitch = Mathf.Clamp(_pitch, -90, 90);
        }

        var speed = BaseSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = RunSpeed;
        }
        var translation = new Vector3();
        translation += Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * speed;
        translation += Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            translation += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            translation += Vector3.down * Time.deltaTime * speed;
        }

        var rotatedTranslation = Quaternion.Euler(0, _yaw, 0) * translation;
        transform.position += rotatedTranslation;
        transform.eulerAngles = new Vector3(_pitch, _yaw, 0);
    }
}