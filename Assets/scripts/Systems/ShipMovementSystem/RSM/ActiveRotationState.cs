using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ActiveRotationState : RotationBaseState
{
    private Rigidbody rb;
    private float rotationTorque;
    public ActiveRotationState(RotationStateManager rotationStateManager, float rotationTorque, Rigidbody rb) : base(rotationStateManager)
    {
        this.rb = rb;
        this.rotationTorque = rotationTorque;
    }
    public override void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    {
        if (rotationActionValue != 0)
        {
            ApplyTorque(rotationActionValue, trans);
        }
        else if (localT != 0)
        {
            DampenTorque(localT, trans);
        }
        else
        {
            RotationBaseState idleRotatingState = rotationStateManager.IdleRotationState;
            SwitchState(idleRotatingState);
        }
    }
    private void ApplyTorque(float rotationActionValue, Vector3 trans)
    {
        rb.AddTorque(trans * Time.fixedDeltaTime * rotationTorque * rotationActionValue*-1, ForceMode.Acceleration);
    }
    private void DampenTorque(float localT, Vector3 trans)
    {
        Debug.Log("Dampening");
        if (localT > 0)
        {
            rb.AddTorque(trans * Time.fixedDeltaTime * rotationTorque*-1, ForceMode.Acceleration);
        }
        else if (localT < 0) { rb.AddTorque(trans * Time.fixedDeltaTime * rotationTorque, ForceMode.Acceleration); }
    }
}