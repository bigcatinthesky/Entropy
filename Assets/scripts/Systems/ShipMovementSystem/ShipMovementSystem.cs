using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ShipMovmentSystem : MonoBehaviour
{
    private StateManager stateManagerX;
    private StateManager stateManagerY;
    private StateManager stateManagerZ;
    private RotationStateManager rotationStateManagerX;
    private RotationStateManager rotationStateManagerY;
    private RotationStateManager rotationStateManagerZ;

    private ShipManager shipManager;
    // private Rigidbody rb;
    // private Transform trans;
    // private float foreAcclerationForce;
    // private float aftAccelerationForce;
    // private float tangentAcclerationForce;
    // private float torqueForce;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;

    private List<ParticleSystem> forwardThrusters;
    private List<ParticleSystem> backwardThrusters;
    private List<ParticleSystem> leftThrusters;
    private List<ParticleSystem> rightThrusters;
    private List<ParticleSystem> upThrusters;
    private List<ParticleSystem> downThrusters;
    // [SerializeField] private List<ParticleSystem> VTOLThrusters;

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

    void Start()
    {
        shipManager = GetComponent<ShipManager>();
        // rb = shipManager.Rb;
        // trans = shipManager.Trans;

        //DisableThrusters(positiveThrustersX);

        stateManagerX = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb);
        stateManagerY = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, shipManager.Rb);
        stateManagerZ = new StateManager(false, shipManager.ShipProfile.ForeAcclerationForce, shipManager.ShipProfile.AftAccelerationForce, shipManager.Rb);

        rotationStateManagerX = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb);
        rotationStateManagerY = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb);
        rotationStateManagerZ = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb);
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
        Debug.Log(localT);
        Debug.Log(rotationStateManagerX.CurrentState);
        Debug.Log(rotationStateManagerY.CurrentState);
        Debug.Log(rotationStateManagerZ.CurrentState);
    }

    public void getThrusters(ThrusterEffectInfo thrusterEffectInfo)
    {
        
    }
}
