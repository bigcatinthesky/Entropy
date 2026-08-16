using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using System;
using Unity.Mathematics;

public class ShipMovementSystem : MonoBehaviour
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
        moveThrusters = new Dictionary<string, List<ParticleSystem>>
        {
            { "upThrusters", new List<ParticleSystem>() },
            { "downThrusters", new List<ParticleSystem>() },
            { "leftThrusters", new List<ParticleSystem>() },
            { "rightThrusters", new List<ParticleSystem>() },
            { "foreThrusters", new List<ParticleSystem>() },
            { "aftThrusters", new List<ParticleSystem>() }
        };
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
        stateManagerX.UpdateState(move.action.ReadValue<Vector3>().x, (float)Math.Round(localV.x,2), shipManager.Trans.right);
        stateManagerY.UpdateState(move.action.ReadValue<Vector3>().y*-1, (float)Math.Round(localV.y,2), shipManager.Trans.up);
        stateManagerZ.UpdateState(move.action.ReadValue<Vector3>().z, (float)Math.Round(localV.z,2), shipManager.Trans.forward);

        Vector3 localT = transform.InverseTransformDirection(shipManager.Rb.angularVelocity);
        rotationStateManagerX.UpdateState(rotate.action.ReadValue<Vector3>().x, (float)Math.Round(localT.x,2), shipManager.Trans.right);
        rotationStateManagerY.UpdateState(rotate.action.ReadValue<Vector3>().y, (float)Math.Round(localT.y,2), shipManager.Trans.up);
        rotationStateManagerZ.UpdateState(rotate.action.ReadValue<Vector3>().z, (float)Math.Round(localT.z,2), shipManager.Trans.forward);
        // Debug.Log(localT);
        // Debug.Log(rotationStateManagerX.CurrentState);
        // Debug.Log(rotationStateManagerY.CurrentState);
        // Debug.Log(rotationStateManagerZ.CurrentState);
    }
}
