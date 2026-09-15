using UnityEngine;
using System.Collections.Generic;

public abstract class RotationBaseState
{
    protected List<ThrusterEffectInfo> rotateThrusters;
    protected RotationStateManager rotationStateManager;
    protected RotationBaseState(RotationStateManager rotationStateManager, List<ThrusterEffectInfo> rotateThrusters)
    {
        this.rotationStateManager = rotationStateManager;
        this.rotateThrusters = rotateThrusters;
    }
    public abstract void UpdateState(float rotationActionValue, float localT, Vector3 trans);
    public abstract void EnterState();
    // protected void SwitchState(RotationBaseState newState)
    // {
    //     rotationStateManager.CurrentState = newState;
    // }
    protected void ApplyTorque(float rotationActionValue, Vector3 trans, Rigidbody rb, float rotationTorque)
    {
        rb.AddTorque(trans * Time.fixedDeltaTime * rotationTorque * rotationActionValue*-1, ForceMode.Acceleration);
    }
    protected void ToggleThrusters(bool activeInactive)
    {
        if (rotateThrusters != null)
        {
            for (int i = 0; i < rotateThrusters.Count; i++)
            {
                rotateThrusters[i].ToggleThrusterActiveInactive(activeInactive);
            }
        }
    }
}
