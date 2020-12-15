using UnityEngine;

public class ConstantForceLabel : BaseLabel
{
    public ConstantForce ConstantForce;

    protected override string GetLabelText()
    {
        Vector3 targetForce = ConstantForce.force;
        if (ConstantForce.relativeForce != Vector3.zero)
        {
            targetForce = ConstantForce.relativeForce;
        }
        var targetTorque = ConstantForce.torque;
        if (ConstantForce.relativeTorque != Vector3.zero)
        {
            targetTorque = ConstantForce.relativeTorque;
        }
        return $"F {targetForce.x},{targetForce.y},{targetForce.z} T {targetTorque.x},{targetTorque.y},{targetTorque.z}";
    }
}
