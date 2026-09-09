using UnityEngine;

public class ThrusterEffectOffState : ThrusterEffectBaseState
{
    public ThrusterEffectOffState(ThrusterEffectStateManager thrusterEffectStateManager, ThrusterEffectInfo thrusterEffectInfo) : base(thrusterEffectStateManager, thrusterEffectInfo) {}

    public override void EnterState() { thrusterOn = false; }
}
