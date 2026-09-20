using UnityEngine;

public class ThrusterEffectSubstateInactive : ThrusterEffectBaseSubstate
{
    public ThrusterEffectSubstateInactive(ThrusterEffectOnState superState, ThrusterEffectInfo thrusterEffectInfo) : base(superState, thrusterEffectInfo) {}

    public override void EnterState() { SetThrusterStartSpeed(0); }
}
