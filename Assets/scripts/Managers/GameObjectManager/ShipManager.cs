using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipManager : VehicleTypeBase
{
    [SerializeField] private ShipProfile shipProfile;
    public ShipProfile ShipProfile { get { return shipProfile; } }
    void Start()
    {
            
    }

    void FixedUpdate()
    {
        
    }
}
