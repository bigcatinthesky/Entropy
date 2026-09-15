using UnityEngine;
using System.Collections.Generic;
using Mono.Cecil.Cil;

public abstract class BaseState
{
    protected StateManager stateManager;
    protected bool dampen;
    protected List<ThrusterEffectInfo> moveThrusters;
    protected BaseState(StateManager stateManager, bool dampen, List<ThrusterEffectInfo> moveThrusters)
    {
        this.stateManager = stateManager;
        this.dampen = dampen;
        this.moveThrusters = moveThrusters;
    }
    public abstract void UpdateState(float moveActionValue, float localV, Vector3 trans);
    public abstract void EnterState();
    protected void Accelerate(float moveActionValue, Vector3 trans, Rigidbody rb, float accelerationForce)
    {
        rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce * moveActionValue*-1, ForceMode.Force);
    }
}
