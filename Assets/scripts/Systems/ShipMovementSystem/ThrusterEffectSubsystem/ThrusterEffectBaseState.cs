using UnityEngine;

public abstract class ThrusterEffectBaseState
{
    protected ThrusterEffectStateManager thrusterEffectStateManager;
    protected ThrusterEffectInfo thrusterEffectInfo;
    protected bool doThrust;
    public ThrusterEffectBaseState(ThrusterEffectStateManager thrusterEffectStateManager, ThrusterEffectInfo thrusterEffectInfo)
    {
        this.thrusterEffectStateManager = thrusterEffectStateManager;
        this.thrusterEffectInfo = thrusterEffectInfo;
    }
    public void EnterState()
    {
        var emission = thrusterEffectInfo.ParticleSystem.emission;
        emission.enabled = doThrust;
    }
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
