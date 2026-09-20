using UnityEngine;
using UnityEngine.InputSystem;
public class RotateRB : MonoBehaviour

{
    public Rigidbody rb;
    public float torque = 1f;

    [Header("Input Actions")]
    public InputActionReference rotate;
    private void OnEnable()
    {
        rotate.action.Enable();
    }

    private void OnDisable()
    {
        rotate.action.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity =  2;
    }

    void FixedUpdate()
    {
        Vector3 m_input = new Vector3(rotate.action.ReadValue<Vector3>().x, rotate.action.ReadValue<Vector3>().y, rotate.action.ReadValue<Vector3>().z);
        m_input = m_input * Time.fixedDeltaTime * torque;
        rb.AddRelativeTorque(m_input.x, m_input.y, m_input.z, ForceMode.Acceleration);

    }
}
