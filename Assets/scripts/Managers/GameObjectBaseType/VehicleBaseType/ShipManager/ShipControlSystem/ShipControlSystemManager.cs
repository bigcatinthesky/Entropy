using Unity.VisualScripting;
using UnityEngine;

public class ShipControlSystemManager : MonoBehaviour
{
    // private ShipManager shipManager;
    private ShipControlBaseType activeShipControl;
    private PlayerShipControlType playerShipControlType;
    private ShipManager shipManager;
    public ShipManager ShipManager { get { return shipManager; } }
    public ShipControlBaseType CurrentControlType { get { return activeShipControl; } }

    void Start()
    {
        shipManager = GetComponent<ShipManager>();
        playerShipControlType = GetComponent<PlayerShipControlType>();
        activeShipControl = playerShipControlType;
        Debug.Log(shipManager);
        Debug.Log(activeShipControl);
    }
}
