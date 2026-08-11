using UnityEngine;

[CreateAssetMenu(fileName = "VehicleProfile", menuName = "Scriptable Objects/VehicleProfile/ShipProfile")]
public class ShipProfile : VehicleProfile
{
    [SerializeField] private float foreAcclerationForce;
    [SerializeField] private float aftAccelerationForce;
    [SerializeField] private float tangentAcclerationForce;
    [SerializeField] private float torqueForce;
}
