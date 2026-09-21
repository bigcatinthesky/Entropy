using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipManager : VehicleTypeBase
{
    [SerializeField] private ShipProfile shipProfile;
    private ShipMovementSystem shipMovementSystem;
    private ShipControlSystemManager shipControlSystemManager;
    // private ShipLandingSystem shipLandingSystem;
    // private ShipVTOLSystem shipVTOLSystem;
    public ShipProfile ShipProfile { get { return shipProfile; } }
    public ShipMovementSystem ShipMovementSystem { get { return shipMovementSystem; } }
    public ShipControlSystemManager ShipControlSystemManager { get { return shipControlSystemManager; } }
    public ShipLandingSystem ShipLandingSystem { get { return ShipLandingSystem; } }
    void Start()
    {
        shipMovementSystem = GetComponent<ShipMovementSystem>();
        shipControlSystemManager = GetComponent<ShipControlSystemManager>();
    }
}
