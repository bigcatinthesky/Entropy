using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrusterEffectInfo : MonoBehaviour
{
    private new ParticleSystem particleSystem;
    private ShipMovementSystem shipMovementSystem;
    private ThrusterEffectStateManager thrusterEffectStateManager;
    [SerializeField] private MoveGroup thrusterMoveGroup;
    [SerializeField] private PitchRotateGroup pitchRotateGroup;
    [SerializeField] private YawRotateGroup yawRotateGroup;
    [SerializeField] private RollRotateGroup rollRotateGroup;

    public ParticleSystem ParticleSystem { get { return particleSystem; } }
    [SerializeField] private enum MoveGroup
    {
        aftThrusters,
        foreThrusters,
        rightThrusters,
        leftThrusters,
        upThrusters,
        downThrusters
    }

    [SerializeField] private enum PitchRotateGroup
    {
        pitchPositiveThrusters,
        pitchNegativeThrusters,
        none
    }
    [SerializeField] private enum YawRotateGroup
    {
        yawPositiveThrusters,
        yawNegativeThrusters,
        none
    }
    [SerializeField] private enum RollRotateGroup
    {
        rollPositiveThrusters,
        rollNegativeThrusters,
        none
    }
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
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
    private void FindThrusterList(Dictionary<string,List<ThrusterEffectInfo>> thrusterEffectInfo, string thrusterGroup)
    {
        // Debug.Log(thrusterEffectInfo);
        foreach (KeyValuePair<string, List<ThrusterEffectInfo>> list in thrusterEffectInfo)
        {
            bool found = CheckThruster(list, thrusterGroup);
            if (found) { return; }
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
        ThrusterEffectBaseSubstate newSubstate;
        if (thrusterActive) { newSubstate = thrusterEffectStateManager.ThrusterEffectOnState.ThrusterEffectSubstateActive; }
        else { newSubstate = thrusterEffectStateManager.ThrusterEffectOnState.ThrusterEffectSubstateInactive; }
        thrusterEffectStateManager.ThrusterEffectOnState.CurrentSubstate = newSubstate;
    }
}
