using System.Collections.Generic;


public class OnState : SMSBaseState
{
    private ShipMovementSystem shipMovementSystem;
    public OnState(ShipMovementSystem shipMovementSystem, SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters) : base(sMSStateManager, moveThrusters)
    {
        this.shipMovementSystem = shipMovementSystem;
    }
    public override void UpdateState() { shipMovementSystem.DoFixedUpdate(); }

    public override void EnterState() { ToggleMoveThrusters(true); }
}
