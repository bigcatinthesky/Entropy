using System;
using UnityEngine;

public abstract class VehicleTypeBase : GameObjectTypeBase
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Transform trans;
    public Transform Trans { get { return trans; } }
    public Rigidbody Rb { get { return rb; } }
}
