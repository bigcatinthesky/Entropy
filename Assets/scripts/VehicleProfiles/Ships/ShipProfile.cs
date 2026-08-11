using UnityEngine;

[CreateAssetMenu(fileName = "VehicleProfile", menuName = "Scriptable Objects/VehicleProfile/ShipProfile")]
public class ShipProfile : VehicleProfile
{
    [Header("Acceleration Forces")]
    [SerializeField] private float foreAcclerationForce;
    [SerializeField] private float aftAccelerationForce;
    [SerializeField] private float tangentAcclerationForce;

    [Header("Torque Force")]
    [SerializeField] private float torqueForce;

    public float ForeAcclerationForce { get { return foreAcclerationForce; } }
    public float AftAccelerationForce { get { return aftAccelerationForce; } }
    public float TangentAcclerationForce { get { return tangentAcclerationForce; } }
    public float TorqueForce { get { return torqueForce; } }
}
