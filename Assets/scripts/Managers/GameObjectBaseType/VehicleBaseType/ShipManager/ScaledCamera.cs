using UnityEngine;

public class ScaledCamera : MonoBehaviour
{
    [SerializeField] private Camera main;
    [SerializeField] private float scale;

    private Vector3 mainCamStartPos;
    private Vector3 skyCamStartPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (main == null)
        {
            main = Camera.main;
        }
        mainCamStartPos = main.transform.position;
        skyCamStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mainCamDeltPos = main.transform.position - mainCamStartPos;
        //transform.position = skyCamStartPos + mainCamDeltPos / scale;
        transform.rotation = main.transform.rotation;
    }
}
