using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ThrusterEffectBaseSubstate
{
    protected ThrusterEffectInfo thrusterEffectInfo;
    protected ThrusterEffectOnState superState;
    public ThrusterEffectBaseSubstate(ThrusterEffectOnState superState, ThrusterEffectInfo thrusterEffectInfo)
    {
        this.superState = superState;
        this.thrusterEffectInfo = thrusterEffectInfo;
    }
    public abstract void EnterState();
    
    // takes an int between 0 and 5
    public void SetThrusterStartSpeed(int startSpeed)
    {
        var main = thrusterEffectInfo.ParticleSystem.main;
        main.startSpeed = startSpeed;
    }
}
