using UnityEngine;

public abstract class BaseState
{
    protected StateManager stateManager;
    protected bool dampen;
    protected BaseState(StateManager stateManager, bool dampen)
    {
        this.stateManager = stateManager;
        this.dampen = dampen;
    }
    public abstract void UpdateState(float moveActionValue, float localV, Vector3 trans);
    protected void EnterState()
    {
        stateManager.CurrentState = this;
    }
    protected void SwitchState(BaseState newState)
    {
        newState.EnterState();
    }
}
