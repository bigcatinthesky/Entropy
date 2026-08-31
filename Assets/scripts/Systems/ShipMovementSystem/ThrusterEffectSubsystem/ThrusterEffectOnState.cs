using UnityEngine;

public class ThrusterEffectActiveState : ThrusterEffectBaseState
{
    public ThrusterEffectActiveState(ThrusterEffectStateManager thrusterEffectStateManager, ThrusterEffectInfo thrusterEffectInfo) : base(thrusterEffectStateManager, thrusterEffectInfo) {}
    // Set thruster start speed int between 1 and 5, default = 5
    public void SetThrusterStartSpeed(int startSpeed)
    {
        var main = thrusterEffectInfo.ParticleSystem.main;
        main.startSpeed = startSpeed;
    }
}
