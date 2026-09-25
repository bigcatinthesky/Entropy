using System;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterEffectInfo : MonoBehaviour
{
    // Handles thruster states & effects
    private ParticleSystem particleSystem;
    private ShipMovementSystem shipMovementSystem;
    private ThrusterEffectStateManager thrusterEffectStateManager;
    [SerializeField] private MoveGroup thrusterMoveGroup;
    [SerializeField] private PitchRotateGroup pitchRotateGroup;
    [SerializeField] private YawRotateGroup yawRotateGroup;
    [SerializeField] private RollRotateGroup rollRotateGroup;
    [SerializeField] private SecondaryMoveGroup secondaryMoveGroup;
    public ParticleSystem ParticleSystem { get { return particleSystem; } }
    [Serializable] private enum MoveGroup
    {
        aftThrusters,
        foreThrusters,
        rightThrusters,
        leftThrusters,
        upThrusters,
        downThrusters
    }
    [Serializable] private enum PitchRotateGroup
    {
        none,
        pitchPositiveThrusters,
        pitchNegativeThrusters
    }
    [Serializable] private enum YawRotateGroup
    {
        none,
        yawPositiveThrusters,
        yawNegativeThrusters
    }
    [Serializable] private enum RollRotateGroup
    {
        none,
        rollPositiveThrusters,
        rollNegativeThrusters,
    }
    [Serializable] private enum SecondaryMoveGroup
    {
        none,
        foreThrusters,
        rightThrusters,
        leftThrusters,
        upThrusters,
        downThrusters
    }
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var main = particleSystem.emission;
        main.enabled = false;
        shipMovementSystem = GetShipMovementSystem();
        FindThrusterList(shipMovementSystem.MoveThrusters, thrusterMoveGroup.ToString());
        FindThrusterList(shipMovementSystem.RotateThrusters, pitchRotateGroup.ToString());
        FindThrusterList(shipMovementSystem.RotateThrusters, yawRotateGroup.ToString());
        FindThrusterList(shipMovementSystem.RotateThrusters, rollRotateGroup.ToString());
        thrusterEffectStateManager = new ThrusterEffectStateManager(this);
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
    private void FindThrusterList(Dictionary<string,List<ThrusterEffectInfo>> thrusterEffectInfo, string thrusterGroup) {
        if (thrusterEffectInfo != null) {
            foreach (KeyValuePair<string, List<ThrusterEffectInfo>> list in thrusterEffectInfo)
            {
                bool found = CheckThruster(list, thrusterGroup);
                if (found) { return; }
            }
        }
    }
    // Called on start, checks the thrusters MoveGroup against the KeyValuePair sting, adds to list and returns true if equal, else false
    private bool CheckThruster(KeyValuePair<string, List<ThrusterEffectInfo>> thrusterList, string thrusterGroup)
    {
        if (thrusterList.Key == thrusterGroup)
        {
            thrusterList.Value.Add(this);
            // Debug.Log("added to list");
            return true;
        }
        // Debug.Log("not added to list");
        return false;
    }
    public void ToggleThrusterOnOff(bool thrusterOn)
    {
        if (thrusterOn) { thrusterEffectStateManager.CurrentState = thrusterEffectStateManager.ThrusterEffectOnState; }
        else { thrusterEffectStateManager.CurrentState = thrusterEffectStateManager.ThrusterEffectOffState; }
    }
    public void ToggleThrusterActiveInactive(bool thrusterActive)
    {
        if (thrusterActive) {  thrusterEffectStateManager.ThrusterEffectOnState.CurrentSubstate = thrusterEffectStateManager.ThrusterEffectOnState.ThrusterEffectSubstateActive; }
        else {  thrusterEffectStateManager.ThrusterEffectOnState.CurrentSubstate = thrusterEffectStateManager.ThrusterEffectOnState.ThrusterEffectSubstateInactive; }
    }
}
