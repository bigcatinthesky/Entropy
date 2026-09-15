using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class OnState : SMSBaseState
{
    private StateManager stateManagerX;
    private StateManager stateManagerY;
    private StateManager stateManagerZ;
    private RotationStateManager rotationStateManagerX;
    private RotationStateManager rotationStateManagerY;
    private RotationStateManager rotationStateManagerZ;
    private ShipManager shipManager;
    public OnState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters, Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters, ShipManager shipManager) : base(sMSStateManager, moveThrusters, rotateThrusters)
    {
        this.shipManager = shipManager;
        initStateManagers();
    }
    public override void UpdateState(Transform transform, Vector3 move, Vector3 rotate) 
    {   
        Vector3 localV = transform.InverseTransformDirection(shipManager.Rb.linearVelocity);
        stateManagerX.CurrentState.UpdateState(move.x, (float)Math.Round(localV.x,1), shipManager.Trans.right);
        stateManagerY.CurrentState.UpdateState(move.y*-1, (float)Math.Round(localV.y,1), shipManager.Trans.up);
        stateManagerZ.CurrentState.UpdateState(move.z, (float)Math.Round(localV.z,1), shipManager.Trans.forward);

        Vector3 localT = transform.InverseTransformDirection(shipManager.Rb.angularVelocity);
        rotationStateManagerX.CurrentState.UpdateState(rotate.x, (float)Math.Round(localT.x,2), shipManager.Trans.right);
        rotationStateManagerY.CurrentState.UpdateState(rotate.y, (float)Math.Round(localT.y,2), shipManager.Trans.up);
        rotationStateManagerZ.CurrentState.UpdateState(rotate.z, (float)Math.Round(localT.z,2), shipManager.Trans.forward);
    }
    public override void EnterState() { ToggleMoveThrusters(true); }

    private void initStateManagers()
    {
        stateManagerX = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb, moveThrusters["rightThrusters"], moveThrusters["leftThrusters"]);
        stateManagerY = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb, moveThrusters["downThrusters"], moveThrusters["upThrusters"]);
        stateManagerZ = new StateManager(false, shipManager.ShipProfile.ForeAcclerationForce, shipManager.ShipProfile.AftAccelerationForce, shipManager.Rb, moveThrusters["foreThrusters"], moveThrusters["aftThrusters"]);

        rotationStateManagerX = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, rotateThrusters["pitchNegativeThrusters"],rotateThrusters["pitchPositiveThrusters"]);
        rotationStateManagerY = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, rotateThrusters["yawNegativeThrusters"],rotateThrusters["yawPositiveThrusters"]);
        rotationStateManagerZ = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, rotateThrusters["rollNegativeThrusters"],rotateThrusters["rollPositiveThrusters"]);

    }
}
