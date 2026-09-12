using Unity.VisualScripting;
using UnityEngine;

public class ThrusterEffectOnState : ThrusterEffectBaseState
{
    private ThrusterEffectSubstateActive thrusterEffectSubstateActive;
    private ThrusterEffectSubstateInactive thrusterEffectSubstateInactive; 
    private ThrusterEffectBaseSubstate currentSubstate;
    public ThrusterEffectBaseSubstate CurrentSubstate { get { return currentSubstate; } set { currentSubstate = value; currentSubstate.EnterState(); } }
    public ThrusterEffectSubstateActive ThrusterEffectSubstateActive { get { return thrusterEffectSubstateActive; } }
    public ThrusterEffectSubstateInactive ThrusterEffectSubstateInactive { get { return thrusterEffectSubstateInactive; } }
    public ThrusterEffectOnState(ThrusterEffectStateManager thrusterEffectStateManager, ThrusterEffectInfo thrusterEffectInfo) : base(thrusterEffectStateManager, thrusterEffectInfo)
    {
        doThrust = true;
        thrusterEffectSubstateActive = new ThrusterEffectSubstateActive(this, thrusterEffectInfo);
        thrusterEffectSubstateInactive = new ThrusterEffectSubstateInactive(this, thrusterEffectInfo);
        CurrentSubstate = thrusterEffectSubstateInactive;
    }

    // Set thruster start speed int between 0 and 5, default = 5
    // public void SetThrusterStartSpeed(int startSpeed)
    // {
    //     var main = thrusterEffectInfo.ParticleSystem.main;
    //     main.startSpeed = startSpeed;
    // }
}
