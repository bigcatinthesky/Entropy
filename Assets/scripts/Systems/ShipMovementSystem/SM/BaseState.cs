using UnityEngine;
using System.Collections.Generic;
using Mono.Cecil.Cil;

public abstract class BaseState
{
    protected List<ThrusterEffectInfo> positiveThrusters;
    protected List<ThrusterEffectInfo> negativeThrusters;
    protected StateManager stateManager;
    protected bool dampen;
    protected BaseState(StateManager stateManager, bool dampen)
    {
        this.stateManager = stateManager;
        this.dampen = dampen;
    }
    public abstract void UpdateState(float moveActionValue, float localV, Vector3 trans);
    protected abstract void EnterState();
    protected abstract void ExitState();
    protected void SwitchState(BaseState newState)
    {
        // Debug.Log("switch from "+stateManager.CurrentState+" to "+newState);
        stateManager.CurrentState.ExitState();
        stateManager.CurrentState = newState;
        newState.EnterState();
    }
    // Takes an int between 1 and 5 to set the 'length' of the thruster plume 
    protected void SetThrusterLength(int thrusterLen, List<ThrusterEffectInfo> moveThrusters)
    {
        if(thrusterLen >= 0 && thrusterLen <= 5)
        {
            for(int i = 0; i < moveThrusters.Count; i++)
            {
                moveThrusters[i].SetThrusterStartSpeed(thrusterLen);
            }
        }
        else { throw new System.Exception("ERROR\nvalue is "+thrusterLen.ToString()+"\nvalue must be between 1 and 5"); }
    }
    protected void Accelerate(float moveActionValue, Vector3 trans, Rigidbody rb, float accelerationForce)
    {
        rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce * moveActionValue*-1, ForceMode.Force);
    }
    public void InitStartState()
    {
        stateManager.CurrentState = this;
        EnterState();
    }
}
