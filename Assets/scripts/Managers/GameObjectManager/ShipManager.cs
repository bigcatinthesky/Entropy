using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipManager : VehicleTypeBase
{
    [SerializeField] private ShipProfile shipProfile;
    public ShipProfile ShipProfile { get { return shipProfile; } }
    private ShipMovmentSystem shipMovmentSystem;
    public ShipMovmentSystem ShipMovmentSystem { get { return ShipMovmentSystem; } }
    private ShipLandingSystem shipLandingSystem;
    public ShipLandingSystem ShipLandingSystem { get { return ShipLandingSystem; } }
    void Start()
    {
            
    }

    void FixedUpdate()
    {
        
    }
}
