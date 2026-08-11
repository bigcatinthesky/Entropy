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
    private Rigidbody rb;
    private Transform trans;

    [Header("Acceleration Forces")]
    [SerializeField] private float foreAcclerationForce;
    [SerializeField] private float aftAccelerationForce;
    [SerializeField] private float tangentAcclerationForce;
    [SerializeField] private float torqueForce;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;

    // [Header("Thruster Groups")]
    // [SerializeField] private List<ParticleSystem> forwardThrusters;
    // [SerializeField] private List<ParticleSystem> backwardThrusters;
    // [SerializeField] private List<ParticleSystem> leftThrusters;
    // [SerializeField] private List<ParticleSystem> rightThrusters;
    // [SerializeField] private List<ParticleSystem> upThrusters;
    // [SerializeField] private List<ParticleSystem> downThrusters;
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
        rb = shipManager.Rb;
        trans = shipManager.Trans;

        //DisableThrusters(positiveThrustersX);

        stateManagerX = new StateManager(true, tangentAcclerationForce, tangentAcclerationForce, rb);
        stateManagerY = new StateManager(true, tangentAcclerationForce, tangentAcclerationForce, rb);
        stateManagerZ = new StateManager(false, foreAcclerationForce, aftAccelerationForce, rb);

        rotationStateManagerX = new RotationStateManager(torqueForce, rb);
        rotationStateManagerY = new RotationStateManager(torqueForce, rb);
        rotationStateManagerZ = new RotationStateManager(torqueForce, rb);
    }

    void FixedUpdate()
    {
        Vector3 localV = transform.InverseTransformDirection(rb.linearVelocity);
        stateManagerX.UpdateState(move.action.ReadValue<Vector3>().x, localV.x, trans.right);
        stateManagerY.UpdateState(move.action.ReadValue<Vector3>().y*-1, localV.y, trans.up);
        stateManagerZ.UpdateState(move.action.ReadValue<Vector3>().z, localV.z, trans.forward);

        Vector3 localT = transform.InverseTransformDirection(rb.angularVelocity);
        rotationStateManagerX.UpdateState(rotate.action.ReadValue<Vector3>().x, localT.x, trans.right);
        rotationStateManagerY.UpdateState(rotate.action.ReadValue<Vector3>().y, localT.y, trans.up);
        rotationStateManagerZ.UpdateState(rotate.action.ReadValue<Vector3>().z, localT.z, trans.forward);
        Debug.Log(localT);
        Debug.Log(rotationStateManagerX.CurrentState);
        Debug.Log(rotationStateManagerY.CurrentState);
        Debug.Log(rotationStateManagerZ.CurrentState);
    }

    // void DisableThrusters(List<ParticleSystem> thrusters)
    // {
    //     for (int i = 0; i < thrusters.Count; i++)
    //     {
    //         var main = thrusters[i].emission;
    //         main.enabled = false;
    //     }
    // }
}
