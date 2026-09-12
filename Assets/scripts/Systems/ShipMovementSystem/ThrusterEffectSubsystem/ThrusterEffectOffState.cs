using UnityEngine;

public class ThrusterEffectOffState : ThrusterEffectBaseState
{
    public ThrusterEffectOffState(ThrusterEffectStateManager thrusterEffectStateManager, ThrusterEffectInfo thrusterEffectInfo) : base(thrusterEffectStateManager, thrusterEffectInfo)
    {
        doThrust = false;
    }

}
