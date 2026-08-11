using UnityEngine;

public abstract class VehicleTypeBase : GameObjectTypeBase
{
    [SerializeField] protected Rigidbody rb;
    public Rigidbody Rb { get { return rb; } }
    [SerializeField] protected Transform trans;
    public Transform Trans { get { return trans; } }
}
