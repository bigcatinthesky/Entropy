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

}
