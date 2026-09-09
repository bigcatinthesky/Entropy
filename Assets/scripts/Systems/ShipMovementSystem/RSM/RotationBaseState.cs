using UnityEngine;
using System.Collections.Generic;

public abstract class RotationBaseState
{
    protected List<ThrusterEffectInfo> positiveThrusters;
    protected List<ThrusterEffectInfo> negativeThrusters;
    protected RotationStateManager rotationStateManager;
    protected RotationBaseState(RotationStateManager rotationStateManager)
    {
        this.rotationStateManager = rotationStateManager;
    }
    public abstract void UpdateState(float rotationActionValue, float localT, Vector3 trans);
    public abstract void EnterState();
    public abstract void ExitState();
    protected void SwitchState(RotationBaseState newState)
    {
        Debug.Log("switch from "+rotationStateManager.CurrentState+" to "+newState);
        rotationStateManager.CurrentState.ExitState();
        rotationStateManager.CurrentState = newState;
        newState.EnterState();
    }
    // protected void SetThrusterLength(int thrusterLen, List<ThrusterEffectInfo> moveThrusters)
    // {
    //     if(thrusterLen >= 0 && thrusterLen <= 5)
    //     {
    //         for(int i = 0; i < moveThrusters.Count; i++)
    //         {
    //             moveThrusters[i].ThrusterEffectStateManager.ThrusterEffectOnState.SetThrusterStartSpeed(thrusterLen);
    //         }
    //     }
    //     else { throw new System.Exception("ERROR\nvalue is "+thrusterLen.ToString()+"\nvalue must be between 1 and 5"); }
    // }
    protected void ApplyTorque(float rotationActionValue, Vector3 trans, Rigidbody rb, float rotationTorque)
    {
        rb.AddTorque(trans * Time.fixedDeltaTime * rotationTorque * rotationActionValue*-1, ForceMode.Acceleration);
    }
    public void InitStartState()
    {
        rotationStateManager.CurrentState = this;
        EnterState();
    }
}
