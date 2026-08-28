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
    protected void ToggleMoveThrusters(bool doEmit)
    {
        foreach(KeyValuePair<string,List<ThrusterEffectInfo>> pair in moveThrusters)
        {
            List <ThrusterEffectInfo> list = pair.Value;
            for(int i = 0; i < list.Count; i++)
            {
                list[i].ToggleThruster(doEmit);
            }
        }
    }
    protected void EnterState(bool toggleMoveThrusters)
    {
        ToggleMoveThrusters(toggleMoveThrusters);
    }
    protected void SwitchState(SMSBaseState newState, bool toggleMoveThrusters)
    {
        sMSStateManager.CurrentState = newState;
        newState.EnterState(toggleMoveThrusters);
    }
    public abstract void UpdateState(bool doMove);

}
