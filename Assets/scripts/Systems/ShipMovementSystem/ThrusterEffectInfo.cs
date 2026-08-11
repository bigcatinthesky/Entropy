using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ThrusterEffectInfo : MonoBehaviour
{
    [SerializeField] private ShipMovmentSystem shipMovmentSystem;
    private new ParticleSystem particleSystem;
    [SerializeField] private MoveGroup thrusterMoveGroup;
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
        var doEmit = particleSystem.emission;
        doEmit.enabled = false;
    }

    // Toggle the particle system on or off
    public void ToggleThruster()
    {
        
    }

    // Set thruster start speed between 1 and 5, default = 5
    public void SetThrusterStartSpeed()
    {
        
    }

}
