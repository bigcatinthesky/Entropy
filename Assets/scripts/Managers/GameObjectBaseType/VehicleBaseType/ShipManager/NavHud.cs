using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NavHud : MonoBehaviour
{
    private RectTransform marker;
    private Image image;

    [SerializeField] private Canvas canvas;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Sprite stopped;
    [SerializeField] private Sprite psprite;
    [SerializeField] private Sprite rsprite;

    void Start()
    {
        //canvas = GetComponentInParent<Canvas>();
        //rb = canvas.GetComponentInParent<Rigidbody>();
        marker = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    void Update()
    {

        Vector3 localV = transform.InverseTransformDirection(rb.linearVelocity);
        marker.anchoredPosition = new Vector2(localV.x, localV.y);
        if (Mathf.Round(localV.z) == 0)
        {
            image.sprite = stopped;
        }
        else if (localV.z > 0) { image.sprite = psprite; }
        else { image.sprite = rsprite; }

 

    }
}
