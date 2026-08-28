using UnityEngine;
using System.Collections.Generic;

public class OffState : SMSBaseState
{
    public OffState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters) : base(sMSStateManager, moveThrusters) {}

    public override void UpdateState(bool doMove)
    {
        if(doMove) { SwitchState(sMSStateManager.OnState, true); }
    }
}
