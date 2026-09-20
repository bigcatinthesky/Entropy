using UnityEngine;
using System.Collections.Generic;
using Mono.Cecil.Cil;

public abstract class BaseState
{
    protected StateManager stateManager;
    protected bool dampen;
    protected List<ThrusterEffectInfo> moveThrusters;
    private OnState smsOnState;
    protected BaseState(StateManager stateManager, bool dampen, List<ThrusterEffectInfo> moveThrusters, OnState smsOnState)
    {
        this.smsOnState = smsOnState;
        this.stateManager = stateManager;
        this.dampen = dampen;
        this.moveThrusters = moveThrusters;
    }
    public abstract void UpdateState(float moveActionValue, float localV, Vector3 trans);
    public abstract void EnterState();
    public abstract void ExitState();
    protected void Accelerate(float moveActionValue, Vector3 trans, Rigidbody rb, float accelerationForce)
    {
        rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce * moveActionValue*-1, ForceMode.Force);
    }
    protected void ToggleThrusters(bool toggleThrusters)
    {
        smsOnState.ToggleThrusters(toggleThrusters, moveThrusters);
    }
}
