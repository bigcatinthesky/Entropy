using UnityEngine;

public class ThrusterEffectStateManager
{
    private ThrusterEffectBaseState currentState;
    private ThrusterEffectInactiveState thrusterEffectInactiveState;
    private ThrusterEffectActiveState thrusterEffectActiveState;
    public ThrusterEffectBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public ThrusterEffectInactiveState ThrusterEffectInactiveState { get { return thrusterEffectInactiveState; } }
    public ThrusterEffectActiveState ThrusterEffectActiveState { get { return thrusterEffectActiveState; } }

    public ThrusterEffectStateManager(ThrusterEffectInfo thrusterEffectInfo)
    {
        thrusterEffectInactiveState = new ThrusterEffectInactiveState(this, thrusterEffectInfo);
        thrusterEffectActiveState = new ThrusterEffectActiveState(this, thrusterEffectInfo);
        thrusterEffectActiveState.InitNewState();
    }
}
