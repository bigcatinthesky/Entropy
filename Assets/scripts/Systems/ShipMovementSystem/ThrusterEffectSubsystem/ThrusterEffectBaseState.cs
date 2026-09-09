using UnityEngine;

public abstract class ThrusterEffectBaseState
{
    protected bool thrusterOn;
    protected ThrusterEffectStateManager thrusterEffectStateManager;
    protected ThrusterEffectInfo thrusterEffectInfo;
    public ThrusterEffectBaseState(ThrusterEffectStateManager thrusterEffectStateManager, ThrusterEffectInfo thrusterEffectInfo)
    {
        this.thrusterEffectStateManager = thrusterEffectStateManager;
        this.thrusterEffectInfo = thrusterEffectInfo;
        thrusterOn = thrusterEffectInfo.ParticleSystem.emission.enabled;
    }
    protected void SwitchState(ThrusterEffectBaseState newState)
    {
        thrusterEffectStateManager.CurrentState = newState;
        newState.EnterState();
    }
    public abstract void EnterState();
    // public void InitNewState()
    // {
    //     thrusterEffectStateManager.CurrentState = this;
    // }
    // Toggle the particle system on or off
    // public void ToggleThruster(bool doThrust)
    // {
    //     var doEmit = thrusterEffectInfo.ParticleSystem.emission;
    //     if (doThrust) 
    //     { 
    //         doEmit.enabled = true;
    //         SwitchState(thrusterEffectStateManager.ThrusterEffectOnState);
    //     }
    //     else 
    //     { 
    //         doEmit.enabled = false;
    //         SwitchState(thrusterEffectStateManager.ThrusterEffectOffState);
    //     }
    // }
}
