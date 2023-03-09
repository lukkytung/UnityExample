using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private Camera cam;
    private Vector3 screenPoint;
    private Vector3 worldPoint;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

    }

    void Update()
    {
        MouseControl();

        // TouchControl();

        // KeyboardControl();

    }

    /// <summary>
    /// 鼠标控制
    /// </summary>
    private void MouseControl()
    {
        if (Input.GetMouseButton(0))
        {
            screenPoint = Input.mousePosition;
            screenPoint.z = cam.nearClipPlane + 5;
            // worldPoint = cam.ScreenToViewportPoint(screenPoint);
              worldPoint = cam.ScreenToWorldPoint(screenPoint);
            transform.position = worldPoint;
            Debug.Log("=====mousePosition:" + screenPoint);
            Debug.Log("=====rb.position:" + worldPoint);
        }
    }
    /// <summary>
    /// 触控控制
    /// </summary>
    private void TouchControl()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                screenPoint = touch.position;
                screenPoint.z = cam.nearClipPlane + 5;
                rb.position = cam.ScreenToWorldPoint(screenPoint);
                Debug.Log("=====Touch Position:" + touch.position);
                Debug.Log("=====rb.position:" + rb.position);
            }
        }
    }
    /// <summary>
    /// 键盘控制
    /// </summary>
    private void KeyboardControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.position = new Vector3(horizontal, vertical, rb.position.z);

    }
}
