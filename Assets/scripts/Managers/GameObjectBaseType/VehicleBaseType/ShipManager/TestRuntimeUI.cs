using System;
using TMPro;
using UnityEngine;

public class TestRuntimeUI : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    private Canvas canvas;
    private Rigidbody rb;
    private void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        canvas = GetComponentInParent<Canvas>();
        rb = canvas.GetComponentInParent<Rigidbody>();
        //Debug.Log("awake");
    }
    void Update()
    {
        //String obj;
        //Debug.Log("update");
        //if (DropContainer.score == DropContainer.goal)
        //{
        //    obj = "OBJECTIVE COMPLETE";
        //}
        //else
        //{
        //    obj = DropContainer.score + " / " + DropContainer.goal+" CONTAINERS";
        //}
        Vector3 localV = transform.InverseTransformDirection(rb.linearVelocity);
        m_TextComponent.text = "RVEL:"+Mathf.Round(localV.magnitude)+"\nXVEL:" + Mathf.Round(localV.x)+"\nYVEL:"+Mathf.Round(localV.y)+"\nZVEL:" + Mathf.Round(localV.z);

    }



}