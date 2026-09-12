using UnityEngine;
using System.Collections.Generic;

public abstract class SMSBaseState
{
    protected SMSStateManager sMSStateManager;
    protected Dictionary<string,List<ThrusterEffectInfo>>  moveThrusters;
    public SMSBaseState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters) 
    { 
        this.sMSStateManager = sMSStateManager;
        this.moveThrusters = moveThrusters;
    }
    protected void ToggleMoveThrusters(bool doMove)
    {
        foreach(KeyValuePair<string,List<ThrusterEffectInfo>> pair in moveThrusters)
        {
            List <ThrusterEffectInfo> list = pair.Value;
            for(int i = 0; i < list.Count; i++)
            {
                list[i].ToggleThrusterOnOff(doMove);
            }
        }
    }
    public abstract void EnterState();
    public abstract void UpdateState();

}
