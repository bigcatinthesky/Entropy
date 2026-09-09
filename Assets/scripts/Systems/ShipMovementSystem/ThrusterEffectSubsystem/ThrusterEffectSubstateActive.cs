using Mono.Cecil.Cil;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class ThrusterEffectSubstateActive : ThrusterEffectBaseSubstate
{
    public ThrusterEffectSubstateActive(ThrusterEffectOnState superState, ThrusterEffectInfo thrusterEffectInfo) : base(superState, thrusterEffectInfo) {}
}
