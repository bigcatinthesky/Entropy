using System;
using UnityEngine;

public abstract class VehicleTypeBase : GameObjectTypeBase
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Transform trans;
    protected VehicleControlManager vehicleControlManager;
    public Transform Trans { get { return trans; } }
    public Rigidbody Rb { get { return rb; } }
    public VehicleControlManager VehicleControlManager { get { return vehicleControlManager; } }

    void Start()
    {
        vehicleControlManager = GetComponent<VehicleControlManager>();
    }
}
