using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ThrusterEffectBaseSubstate
{
    protected ThrusterEffectInfo thrusterEffectInfo;
    protected ThrusterEffectOnState superState;
    protected int len;
    public ThrusterEffectBaseSubstate(ThrusterEffectOnState superState, ThrusterEffectInfo thrusterEffectInfo)
    {
        this.superState = superState;
        this.thrusterEffectInfo = thrusterEffectInfo;
    }
    public void EnterState()
    {
        // UnityEngine.Debug.Log(thrusterEffectInfo.ParticleSystem.main);
        len = 0;
        SetThrusterStartSpeed(len);
    }
    // takes an int between 0 and 5
    protected void SetThrusterStartSpeed(int startSpeed)
    {
        var main = thrusterEffectInfo.ParticleSystem.main;
        main.startSpeed = startSpeed;
    }
}
