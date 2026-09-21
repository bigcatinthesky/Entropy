using System;
using UnityEngine;

public class VehicleControlManager : MonoBehaviour
{
    private VehicleTypeBase vehicleTypeBase;
    private PersonellManager personellManager;
    [SerializeField] private VehicleControlBaseType vehicleControlBaseType;
    public PersonellManager PersonellManager { get { return personellManager; } }
    public VehicleTypeBase VehicleTypeBase { get { return vehicleTypeBase; } }
}
