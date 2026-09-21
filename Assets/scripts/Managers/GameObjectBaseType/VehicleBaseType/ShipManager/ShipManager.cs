using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipManager : VehicleTypeBase
{
    [SerializeField] private ShipProfile shipProfile;
    private ShipMovementSystem shipMovementSystem;
    private ShipLandingSystem shipLandingSystem;
    private ShipVTOLSystem shipVTOLSystem;
    public ShipProfile ShipProfile { get { return shipProfile; } }
    public ShipMovementSystem ShipMovmentSystem { get { return ShipMovmentSystem; } }
    public ShipLandingSystem ShipLandingSystem { get { return ShipLandingSystem; } }
    void Start()
    {
        shipMovementSystem = GetComponent<ShipMovementSystem>();
    }
    void FixedUpdate()
    {
        
    }
}
