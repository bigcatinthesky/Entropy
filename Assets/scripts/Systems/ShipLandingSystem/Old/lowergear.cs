using UnityEngine;
using UnityEngine.InputSystem;

public class lowerGear : MonoBehaviour
{
    Animator g_animator;

    public InputActionReference gearDown;

    private void OnEnable()
    {
        gearDown.action.Enable();
    }

    private void OnDisable()
    {
        gearDown.action.Disable();
    }
    void Start()
    {
        g_animator = gameObject.GetComponent<Animator>();
        g_animator.SetBool("run", false);
        Debug.Log("run false");
    }

    
    void FixedUpdate()
    {
        if (gearDown.action.IsPressed())
        {
            g_animator.SetBool("run", true);
            Debug.Log("run true");
        }

    }
}
