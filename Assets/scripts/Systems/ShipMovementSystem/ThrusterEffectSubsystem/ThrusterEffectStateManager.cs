using UnityEngine;

public class ThrusterEffectStateManager
{
    private ThrusterEffectBaseState currentState;
    private ThrusterEffectOffState thrusterEffectOffState;
    private ThrusterEffectOnState thrusterEffectOnState;
    public ThrusterEffectBaseState CurrentState { get { return currentState; } set { currentState = value; currentState.EnterState(); } }
    public ThrusterEffectOffState ThrusterEffectOffState { get { return thrusterEffectOffState; } }
    public ThrusterEffectOnState ThrusterEffectOnState { get { return thrusterEffectOnState; } }

    public ThrusterEffectStateManager(ThrusterEffectInfo thrusterEffectInfo)
    {
        thrusterEffectOffState = new ThrusterEffectOffState(this, thrusterEffectInfo);
        thrusterEffectOnState = new ThrusterEffectOnState(this, thrusterEffectInfo);
    }
}
