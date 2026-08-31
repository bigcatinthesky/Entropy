using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;
using System.Linq;

public class ShipMovementSystem : MonoBehaviour
{
    //Temp, to be replaced by control system
    [Header("Input Actions")]
    [SerializeField] private bool doEmit;
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;

    private SMSStateManager sMSStateManager;
    private StateManager stateManagerX;
    private StateManager stateManagerY;
    private StateManager stateManagerZ;
    private RotationStateManager rotationStateManagerX;
    private RotationStateManager rotationStateManagerY;
    private RotationStateManager rotationStateManagerZ;
    private ShipManager shipManager;
    private Dictionary<string,List<ThrusterEffectInfo>> moveThrusters;
    private Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters;
    public Dictionary<string,List<ThrusterEffectInfo>> RotateThrusters { get { return rotateThrusters; } }
    public Dictionary<string,List<ThrusterEffectInfo>> MoveThrusters { get { return moveThrusters; } }


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
        sMSStateManager = new SMSStateManager(this, moveThrusters);

        stateManagerX = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb, moveThrusters["rightThrusters"], moveThrusters["leftThrusters"]);
        stateManagerY = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb, moveThrusters["downThrusters"], moveThrusters["upThrusters"]);
        stateManagerZ = new StateManager(false, shipManager.ShipProfile.ForeAcclerationForce, shipManager.ShipProfile.AftAccelerationForce, shipManager.Rb, moveThrusters["foreThrusters"], moveThrusters["aftThrusters"]);

        rotationStateManagerX = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, rotateThrusters["pitchNegativeThrusters"],rotateThrusters["pitchPositiveThrusters"]);
        rotationStateManagerY = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, rotateThrusters["yawNegativeThrusters"],rotateThrusters["yawPositiveThrusters"]);
        rotationStateManagerZ = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, rotateThrusters["rollNegativeThrusters"],rotateThrusters["rollPositiveThrusters"]);
    }

    private void initThrusters()
    {
        moveThrusters = new Dictionary<string, List<ThrusterEffectInfo>>
        {
            { "upThrusters", new List<ThrusterEffectInfo>() },
            { "downThrusters", new List<ThrusterEffectInfo>() },
            { "leftThrusters", new List<ThrusterEffectInfo>() },
            { "rightThrusters", new List<ThrusterEffectInfo>() },
            { "foreThrusters", new List<ThrusterEffectInfo>() },
            { "aftThrusters", new List<ThrusterEffectInfo>() }
        };
        rotateThrusters = new Dictionary<string,List<ThrusterEffectInfo>>
        {
            { "pitchPositiveThrusters", new List<ThrusterEffectInfo>() },
            { "pitchNegativeThrusters", new List<ThrusterEffectInfo>() },
            { "yawPositiveThrusters", new List<ThrusterEffectInfo>() },
            { "yawNegativeThrusters", new List<ThrusterEffectInfo>() },
            { "rollPositiveThrusters", new List<ThrusterEffectInfo>() },
            { "rollNegativeThrusters", new List<ThrusterEffectInfo>() }
        };
    }

    void Start()
    {
        shipManager = GetComponent<ShipManager>();
        initThrusters();
        initStateManagers();
        
    }

    void FixedUpdate()
    {
        sMSStateManager.UpdateState(doEmit);
    }

    public void DoFixedUpdate()
    {
        Vector3 localV = transform.InverseTransformDirection(shipManager.Rb.linearVelocity);
        stateManagerX.UpdateState(move.action.ReadValue<Vector3>().x, (float)Math.Round(localV.x,1), shipManager.Trans.right);
        stateManagerY.UpdateState(move.action.ReadValue<Vector3>().y*-1, (float)Math.Round(localV.y,1), shipManager.Trans.up);
        stateManagerZ.UpdateState(move.action.ReadValue<Vector3>().z, (float)Math.Round(localV.z,1), shipManager.Trans.forward);

        Vector3 localT = transform.InverseTransformDirection(shipManager.Rb.angularVelocity);
        rotationStateManagerX.UpdateState(rotate.action.ReadValue<Vector3>().x, (float)Math.Round(localT.x,2), shipManager.Trans.right);
        rotationStateManagerY.UpdateState(rotate.action.ReadValue<Vector3>().y, (float)Math.Round(localT.y,2), shipManager.Trans.up);
        rotationStateManagerZ.UpdateState(rotate.action.ReadValue<Vector3>().z, (float)Math.Round(localT.z,2), shipManager.Trans.forward);
    }
}
