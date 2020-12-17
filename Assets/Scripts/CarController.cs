using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private bool isBreaking;

    [SerializeField] private Vector3 centerOfMass;

    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float netralTorque;
    [SerializeField] private float breakTorque;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private bool inputEnabled = true;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        if (inputEnabled)
        {
            horizontalInput = Input.GetAxis(HORIZONTAL);
            verticalInput = Input.GetAxis(VERTICAL);
            isBreaking = Input.GetKey(KeyCode.Space);
        }
    }

    private void HandleMotor()
    {
        var motorTorque = verticalInput * maxMotorTorque;
        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;
        rearLeftWheelCollider.motorTorque = motorTorque;
        rearRightWheelCollider.motorTorque = motorTorque;
        var currentBreakTorque = 0f;
        if (isBreaking)
        {
            currentBreakTorque = breakTorque;
        }
        else if (motorTorque == 0)
        {
            currentBreakTorque = netralTorque;
        }
        frontRightWheelCollider.brakeTorque = currentBreakTorque;
        frontLeftWheelCollider.brakeTorque = currentBreakTorque;
        rearLeftWheelCollider.brakeTorque = currentBreakTorque;
        rearRightWheelCollider.brakeTorque = currentBreakTorque;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
