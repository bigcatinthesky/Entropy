using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class OffState : SMSBaseState
{
    public OffState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters, Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters) : base(sMSStateManager, moveThrusters, rotateThrusters) {}
    public override void UpdateState(Transform transform, Vector3 move, Vector3 rotate) {}
    public override void EnterState() { ToggleMoveThrusters(false); }
}
