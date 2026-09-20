using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ActiveDock : MonoBehaviour
{

    [Header("Input Actions")]
    public InputActionReference release;
    private void OnEnable()
    {
        release.action.Enable();
    }

    private void OnDisable()
    {
        release.action.Disable();
    }
    private void OnTriggerEnter(Collider collision)
    {
      
        Debug.Log("triggered");
        if (collision.gameObject.name == "cargocontainer")
        {
            if (gameObject.transform.Find("cargocontainer") == null)
            {
                Debug.Log("angle:" + Quaternion.Angle(collision.transform.rotation, gameObject.transform.rotation));
                if (Quaternion.Angle(collision.transform.rotation, gameObject.transform.rotation) > 165 || Quaternion.Angle(collision.transform.rotation, gameObject.transform.rotation) < 15)
                {
                    Debug.Log("container lock");
                    Rigidbody rb = collision.GetComponent<Rigidbody>();
                    Destroy(rb);
                    collision.transform.SetParent(gameObject.transform);
                    collision.transform.localPosition = new Vector3(8, -3, 0);
                    collision.transform.localRotation = new Quaternion(0, 0, 0, 0);
                }
                else { Debug.Log("match angle"); }
            }
            else { Debug.Log("container already attached"); }
        }
        else { Debug.Log("incompatible container"); }
    }

    void FixedUpdate()
    {
        if (release.action.IsPressed())
        {
            Transform c = gameObject.transform.Find("cargocontainer");
            if (c != null)
            {
                c.AddComponent<Rigidbody>();
                Rigidbody crb = c.GetComponent<Rigidbody>();
                crb.useGravity = false;
                c.SetParent(null);

               
            }
            else { Debug.Log("no container attached"); }

        }

    }
}
