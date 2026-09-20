using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MoveRigidBody : MonoBehaviour
{

    public Rigidbody rb;
    public float  moveSpeed = 100f;
    private float foremultiplier = 4;
    private float aftmultiplier = 2;

    [Header("Input Actions")]
    public InputActionReference move;

    private void OnEnable()
    {

        move.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxLinearVelocity = 100;
    }

    void FixedUpdate()
    {
        float multiplier;
        Vector3 localV = transform.InverseTransformDirection(rb.linearVelocity);
        if (move.action.ReadValue<Vector3>().y == 0 && localV.y != 0)
        {
            if (localV.y > 0)
            {
                rb.AddForce(transform.up * Time.fixedDeltaTime * moveSpeed * -1, ForceMode.Acceleration);
            }
            else if (localV.y < 0)
            {
                rb.AddForce(transform.up * Time.fixedDeltaTime * moveSpeed, ForceMode.Acceleration);
            }
        }
        else
        {
            rb.AddForce(transform.up * Time.fixedDeltaTime * moveSpeed * move.action.ReadValue<Vector3>().y, ForceMode.Acceleration);
        }
        if (move.action.ReadValue<Vector3>().x == 0 && localV.x != 0)
        {
            if (localV.x > 0)
            {
                rb.AddForce(transform.right * Time.fixedDeltaTime * moveSpeed * -1, ForceMode.Acceleration);
            }
            else if (localV.x < 0)
            {
                rb.AddForce(transform.right * Time.fixedDeltaTime * moveSpeed, ForceMode.Acceleration);
            }
        }
        else
        {
            rb.AddForce(transform.right * Time.fixedDeltaTime * moveSpeed * move.action.ReadValue<Vector3>().x*-1, ForceMode.Acceleration);
        }

        if (move.action.ReadValue<Vector3>().z > 0)
        {
            multiplier = foremultiplier;
        }
        else
        {
            multiplier = aftmultiplier;
        }
        rb.AddForce(transform.forward * Time.fixedDeltaTime * moveSpeed * move.action.ReadValue<Vector3>().z * multiplier * -1, ForceMode.Acceleration);
    }

}