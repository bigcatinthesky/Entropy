using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ThrusterEffectInfo : MonoBehaviour
{
    private new ParticleSystem particleSystem;
    [SerializeField] private ShipMovmentSystem shipMovmentSystem;
    [SerializeField] private MoveGroup thrusterMoveGroup;
    public MoveGroup ThrusterMoveGroup { get {return thrusterMoveGroup; } }
    // [SerializeField] private RotateGroup thrusterRotateGroup;
    // public RotateGroup ThrusterRotateGroup { get { return thrusterRotateGroup; } }

        public enum MoveGroup
    {
        backwardThruster,
        forwardThruster,
        rightThruster,
        leftThruster,
        upThruster,
        downThruster
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
        ToggleThruster(false);
        shipMovmentSystem.getThrusters(this);
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
