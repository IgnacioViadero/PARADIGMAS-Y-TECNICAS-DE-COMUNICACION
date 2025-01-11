using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float throttleInput;
    public float brakeInput;
    public float turnInput;
    public float engineForce;
    public float brakeForce;
    public float driftAngle;
    private float currentSpeed;
    public AnimationCurve steeringCurve;

    private Rigidbody vehicleRigidbody;
    public WheelConfiguration wheelColliders;
    public WheelVisuals wheelMeshes;

    void Awake()
    {
        vehicleRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        currentSpeed = vehicleRigidbody.velocity.magnitude;
        HandleInput();
        ControlEngine();
        ControlSteering();
        ControlBraking();
        UpdateWheelTransforms();
    }

    void HandleInput()
    {
        throttleInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        driftAngle = Vector3.Angle(transform.forward, vehicleRigidbody.velocity - transform.forward);

        float movementDirection = Vector3.Dot(transform.forward, vehicleRigidbody.velocity);
        if (movementDirection < -0.5f && throttleInput > 0)
        {
            brakeInput = Mathf.Abs(throttleInput);
        }
        else if (movementDirection > 0.5f && throttleInput < 0)
        {
            brakeInput = Mathf.Abs(throttleInput);
        }
        else
        {
            brakeInput = 0;
        }
    }

    void ControlBraking()
    {
        wheelColliders.frontRight.brakeTorque = brakeInput * brakeForce * 0.7f;
        wheelColliders.frontLeft.brakeTorque = brakeInput * brakeForce * 0.7f;

        wheelColliders.rearRight.brakeTorque = brakeInput * brakeForce * 0.3f;
        wheelColliders.rearLeft.brakeTorque = brakeInput * brakeForce * 0.3f;
    }

    void ControlEngine()
    {
        wheelColliders.rearRight.motorTorque = engineForce * throttleInput;
        wheelColliders.rearLeft.motorTorque = engineForce * throttleInput;
    }

    void ControlSteering()
    {
        float steeringAngle = turnInput * steeringCurve.Evaluate(currentSpeed);
        if (driftAngle < 120f)
        {
            steeringAngle += Vector3.SignedAngle(transform.forward, vehicleRigidbody.velocity + transform.forward, Vector3.up);
        }
        steeringAngle = Mathf.Clamp(steeringAngle, -90f, 90f);
        wheelColliders.frontRight.steerAngle = steeringAngle;
        wheelColliders.frontLeft.steerAngle = steeringAngle;
    }

    void UpdateWheelTransforms()
    {
        AlignWheel(wheelColliders.frontRight, wheelMeshes.frontRight);
        AlignWheel(wheelColliders.frontLeft, wheelMeshes.frontLeft);
        AlignWheel(wheelColliders.rearRight, wheelMeshes.rearRight);
        AlignWheel(wheelColliders.rearLeft, wheelMeshes.rearLeft);
    }

    void AlignWheel(WheelCollider collider, MeshRenderer mesh)
    {
        collider.GetWorldPose(out Vector3 position, out Quaternion rotation);
        mesh.transform.position = position;
        mesh.transform.rotation = rotation;
    }
}

[System.Serializable]
public class WheelConfiguration
{
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider rearRight;
    public WheelCollider rearLeft;
}

[System.Serializable]
public class WheelVisuals
{
    public MeshRenderer frontRight;
    public MeshRenderer frontLeft;
    public MeshRenderer rearRight;
    public MeshRenderer rearLeft;
}
