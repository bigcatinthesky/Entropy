using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public abstract class SMSBaseState
{
    protected SMSStateManager sMSStateManager;
    protected Dictionary<string,List<ThrusterEffectInfo>>  moveThrusters;
    protected Dictionary<string,List<ThrusterEffectInfo>>  rotateThrusters;
    public SMSBaseState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters, Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters) 
    { 
        this.sMSStateManager = sMSStateManager;
        this.moveThrusters = moveThrusters;
        this.rotateThrusters = rotateThrusters;
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
    public abstract void UpdateState(Transform transform, Vector3 move, Vector3 rotate);

}
