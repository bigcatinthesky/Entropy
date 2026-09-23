using System.Collections.Generic;
using UnityEngine;

public class SMSStateManager
{
    private SMSBaseState currentState;
    private OnState onState;
    private OffState offState;
    public SMSBaseState CurrentState { get { return currentState; } }
    public OnState OnState { get { return onState; } }
    public OffState OffState{ get { return offState; } }
    public SMSStateManager(Dictionary<string,List<ThrusterEffectInfo>> moveThrusters, Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters, ShipManager shipManager)
    {
        offState = new OffState(this, moveThrusters, rotateThrusters);
        onState = new OnState(this, moveThrusters, rotateThrusters, shipManager);
        currentState = offState;
        currentState.EnterState();
    }
    public void MoveOn()
    {
        if (currentState != onState) { currentState = onState; }
        currentState.EnterState();
    }
    public void MoveOff()
    {
        if (currentState != offState) { currentState = offState; }
        currentState.EnterState();
    }
    public void ToggleOnOff()
    {
        Debug.Log("toggling");
        if (currentState == onState) { MoveOff(); }
        else { MoveOn(); }
    }
}
