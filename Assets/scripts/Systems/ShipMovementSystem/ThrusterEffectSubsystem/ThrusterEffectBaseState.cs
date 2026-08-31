using UnityEngine;

public abstract class ThrusterEffectBaseState
{
    protected ThrusterEffectStateManager thrusterEffectStateManager;
    protected ThrusterEffectInfo thrusterEffectInfo;
    public ThrusterEffectBaseState(ThrusterEffectStateManager thrusterEffectStateManager, ThrusterEffectInfo thrusterEffectInfo)
    {
        this.thrusterEffectStateManager = thrusterEffectStateManager;
        this.thrusterEffectInfo = thrusterEffectInfo;
    }
    protected void SwitchState(ThrusterEffectBaseState newState)
    {
        thrusterEffectStateManager.CurrentState = newState;
    }
    public void InitNewState()
    {
        thrusterEffectStateManager.CurrentState = this;
    }
    // Toggle the particle system on or off
    public void ToggleThruster(bool doThrust)
    {
        var doEmit = thrusterEffectInfo.ParticleSystem.emission;
        if (doThrust) 
        { 
            doEmit.enabled = true;
            SwitchState(thrusterEffectStateManager.ThrusterEffectActiveState);
        }
        else 
        { 
            doEmit.enabled = false;
            SwitchState(thrusterEffectStateManager.ThrusterEffectInactiveState);
        }
    }
}
