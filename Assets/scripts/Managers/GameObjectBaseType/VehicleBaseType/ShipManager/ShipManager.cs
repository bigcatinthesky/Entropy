using UnityEngine;


public class ShipManager : VehicleTypeBase
{
    [SerializeField] private ShipProfile shipProfile;
    private ShipMovementSystem shipMovementSystem;
    private ShipControlSystemManager shipControlSystemManager;
    private ShipVTOLSystem shipVTOLSystem;
    // private ShipLandingSystem shipLandingSystem;

    public ShipProfile ShipProfile { get { return shipProfile; } }
    public ShipMovementSystem ShipMovementSystem { get { return shipMovementSystem; } }
    public ShipControlSystemManager ShipControlSystemManager { get { return shipControlSystemManager; } }
    public ShipVTOLSystem ShipVTOLSystem { get { return shipVTOLSystem;} }
    // public ShipLandingSystem ShipLandingSystem { get { return ShipLandingSystem; } }
    void Start()
    {
        shipMovementSystem = GetComponent<ShipMovementSystem>();
        shipControlSystemManager = GetComponent<ShipControlSystemManager>();
        shipVTOLSystem = GetComponent<ShipVTOLSystem>();
    }
}
