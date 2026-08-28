using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrusterEffectInfo : MonoBehaviour
{
    private new ParticleSystem particleSystem;
    private ShipMovementSystem shipMovementSystem;
    [SerializeField] private MoveGroup thrusterMoveGroup;
    // [SerializeField] private RotateGroup thrusterRotateGroup;
    // public RotateGroup ThrusterRotateGroup { get { return thrusterRotateGroup; } }

    [SerializeField] private enum MoveGroup
    {
        aftThrusters,
        foreThrusters,
        rightThrusters,
        leftThrusters,
        upThrusters,
        downThrusters
    }

    // public enum RotateGroup
    // {
    //     RotateXPositive,
    //     RotateXNegative,
    //     RotateYPositive,
    //     RotateYNegative,
    //     RotateZPositive,
    //     RotateZNegative,
    //     None
    // }

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        shipMovementSystem = GetShipMovementSystem();

        ToggleThruster(false);
        SetThrusterStartSpeed(0);
        FindThrusterList();
    }
    
    private ShipMovementSystem GetShipMovementSystem() {
        ShipMovementSystem _shipMovementSystem = GetComponent<ShipMovementSystem>();
            if (_shipMovementSystem == null) {
                return GetShipMovementSystem(GetComponentInParent<ShipMovementSystem>());
            }
            else { return _shipMovementSystem; }

    }
    private ShipMovementSystem GetShipMovementSystem(ShipMovementSystem _shipMovementSystem) {
            if (_shipMovementSystem == null) {
                return GetShipMovementSystem(GetComponentInParent<ShipMovementSystem>());
            }
            else { return _shipMovementSystem; }
    }

    // Finds what list in the shipMovement.MoveThrusters dictionary a thruster belongs to by calling CheckThruster on each KeyValuePair
    private void FindThrusterList()
    {
        foreach (KeyValuePair<string, List<ThrusterEffectInfo>> list in shipMovementSystem.MoveThrusters)
        {
            bool found = CheckThruster(list);
            if (found) { return; }
        }
    }
    // Called on start, checks the thrusters MoveGroup against the KeyValuePair sting, adds to list and returns true if equal, else false
    private bool CheckThruster(KeyValuePair<string, List<ThrusterEffectInfo>> thrusterList)
    {
        if (thrusterList.Key == thrusterMoveGroup.ToString())
        {
            thrusterList.Value.Add(this);
            // Debug.Log("added to list");
            return true;
        }
        // Debug.Log("not added to list");
        return false;
    }

    // Toggle the particle system on or off
    public void ToggleThruster(bool doThrust)
    {
        var doEmit = particleSystem.emission;
        if (doThrust) { doEmit.enabled = true; }
        else { doEmit.enabled = false; }
    }

    // Set thruster start speed int between 1 and 5, default = 5
    public void SetThrusterStartSpeed(int startSpeed)
    {
        var main = particleSystem.main;
        main.startSpeed = startSpeed;
    }

}
