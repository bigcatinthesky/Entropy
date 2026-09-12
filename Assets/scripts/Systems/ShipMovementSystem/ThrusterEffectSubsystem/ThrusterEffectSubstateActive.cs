using Mono.Cecil.Cil;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class ThrusterEffectSubstateActive : ThrusterEffectBaseSubstate
{
    private int startSpeed;
    public ThrusterEffectSubstateActive(ThrusterEffectOnState superState, ThrusterEffectInfo thrusterEffectInfo) : base(superState, thrusterEffectInfo) { }

    public override void EnterState()
    {
        startSpeed = 0;
        SetThrusterStartSpeed(startSpeed);
    }

    // expects int 0 - 5
    public void UpdateStartSpeed(int newStartSpeed)
    {
        startSpeed = newStartSpeed;
        SetThrusterStartSpeed(startSpeed);
    }
}
