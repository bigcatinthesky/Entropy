using UnityEngine;

public class AccelerationState : BaseState
{
    private float accelerationForce;
    private Rigidbody rb;
    public AccelerationState(bool dampen, StateManager stateManager, float accelerationForce, Rigidbody rb) : base(stateManager, dampen)
    {
        this.dampen = dampen;
        this.accelerationForce = accelerationForce;
        this.rb = rb;
    }
    public override void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {

        if (moveActionValue != 0)
        {
            Accelerate(moveActionValue, trans);
        }
        else if(dampen == true && localV != 0)
        {
            Dampen(localV, trans);
        }
        else if (dampen == false || (dampen == true && localV == 0))
        {
            BaseState idleState = stateManager.IdleState;
            SwitchState(idleState);
        }
    }
    private void Dampen(float localV, Vector3 trans)
    {
        if (localV > 0)
        {
            rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce*-1, ForceMode.Acceleration);
        }
        else if (localV < 0) { rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce, ForceMode.Acceleration); }

    }
    private void Accelerate(float moveActionValue, Vector3 trans)
    {
        rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce * moveActionValue*-1, ForceMode.Acceleration);
    }
}
