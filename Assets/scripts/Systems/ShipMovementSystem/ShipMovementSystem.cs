using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using System;

public class ShipMovmentSystem : MonoBehaviour
{
    //Temp, to be replaced by control system
    [Header("Input Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;

    private StateManager stateManagerX;
    private StateManager stateManagerY;
    private StateManager stateManagerZ;
    private RotationStateManager rotationStateManagerX;
    private RotationStateManager rotationStateManagerY;
    private RotationStateManager rotationStateManagerZ;
    private ShipManager shipManager;
    private Dictionary<string,List<ParticleSystem>> moveThrusters;
    public Dictionary<string,List<ParticleSystem>> MoveThrusters { get { return moveThrusters; } }

    private void OnEnable()
    {
        move.action.Enable();
        rotate.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
        rotate.action.Disable();
    }
    private void initStateManagers()
    {
        stateManagerX = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb);
        stateManagerY = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb);
        stateManagerZ = new StateManager(false, shipManager.ShipProfile.ForeAcclerationForce, shipManager.ShipProfile.AftAccelerationForce, shipManager.Rb);

        rotationStateManagerX = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb);
        rotationStateManagerY = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb);
        rotationStateManagerZ = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb);
    }

    private void initThrusters()
    {
        moveThrusters = new Dictionary<string, List<ParticleSystem>>();
        moveThrusters.Add("upThrusters", new List<ParticleSystem>());
        moveThrusters.Add("downThrusters", new List<ParticleSystem>());
        moveThrusters.Add("leftThrusters", new List<ParticleSystem>());
        moveThrusters.Add("rightThrusters", new List<ParticleSystem>());
        moveThrusters.Add("foreThrusters", new List<ParticleSystem>());
        moveThrusters.Add("aftThrusters", new List<ParticleSystem>());
    }

    void Start()
    {
        shipManager = GetComponent<ShipManager>();
        initStateManagers();
        initThrusters();
        
    }

    void FixedUpdate()
    {
        Vector3 localV = transform.InverseTransformDirection(shipManager.Rb.linearVelocity);
        stateManagerX.UpdateState(move.action.ReadValue<Vector3>().x, localV.x, shipManager.Trans.right);
        stateManagerY.UpdateState(move.action.ReadValue<Vector3>().y*-1, localV.y, shipManager.Trans.up);
        stateManagerZ.UpdateState(move.action.ReadValue<Vector3>().z, localV.z, shipManager.Trans.forward);

        Vector3 localT = transform.InverseTransformDirection(shipManager.Rb.angularVelocity);
        rotationStateManagerX.UpdateState(rotate.action.ReadValue<Vector3>().x, localT.x, shipManager.Trans.right);
        rotationStateManagerY.UpdateState(rotate.action.ReadValue<Vector3>().y, localT.y, shipManager.Trans.up);
        rotationStateManagerZ.UpdateState(rotate.action.ReadValue<Vector3>().z, localT.z, shipManager.Trans.forward);
        // Debug.Log(localT);
        // Debug.Log(rotationStateManagerX.CurrentState);
        // Debug.Log(rotationStateManagerY.CurrentState);
        // Debug.Log(rotationStateManagerZ.CurrentState);
    }
}
