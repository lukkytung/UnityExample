using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Player刚体
    public Rigidbody rb;
    // 旋转速度
    public float speed = 1f;
    // Star Transform
    public Transform center;
    // 旋转半径
    private float radius = 3;
    // 转动角度
    private float angle = 0;
    // 是否正在长按
    private bool isProgress = false;
    // 加速度
    public float acceleratedSpeed = 1f;

    private void Start()
    {
    }

    void Update()
    {

        // 监听鼠标左键是否按下，并开始计时
        if (Input.GetMouseButton(0))
        {
            isProgress = true;
            // 动态修改旋转位置角度
            angle += Time.deltaTime * speed;
            if (angle >= 360)
            {
                angle -= 360;
            }
            // 动态修改旋转半径
            radius += Time.deltaTime;
            if (radius > 8)
            {
                radius -= Time.deltaTime;

            }
            // 动态修改加速度
            acceleratedSpeed += Time.deltaTime;
            if (acceleratedSpeed >= 2)
            {
                acceleratedSpeed -= Time.deltaTime;
            }
            if (radius <= 8)
            {
                Debug.Log("+++++++Radius:" + radius);
                Debug.Log("=====GetMouseButton=====Angle:" + angle);
                float x = center.position.x + radius * Mathf.Cos(angle);
                float y = center.position.y + radius * Mathf.Sin(angle);
                transform.position = new Vector3(x: x, y: y);
            }

        }
        else if (Input.GetMouseButtonUp(0) || !isProgress && radius > 3)
        {
            isProgress = false;
            radius -= Time.deltaTime;

            Debug.Log("--------Radius:" + radius);
            if (radius < 3)
            {
                radius += Time.deltaTime;
            }

            angle += Time.deltaTime * speed;
            if (angle >= 360)
            {
                angle -= 360;
            }

            Debug.Log("======GetMouseButtonUp====Angle:" + angle);
            float x = center.position.x + radius * Mathf.Cos(angle);
            float y = center.position.y + radius * Mathf.Sin(angle);
            transform.position = new Vector3(x: x, y: y);
        }
        else
        {
            // transform.RotateAround(center.position, Vector3.forward, speed * Time.deltaTime*10);
            radius -= Time.deltaTime;

            Debug.Log("--------Radius:" + radius);
            if (radius < 3)
            {
                radius += Time.deltaTime;
            }

            angle += Time.deltaTime * speed;
            if (angle >= 360)
            {
                angle -= 360;
            }

            Debug.Log("======GetMouseButtonUp====Angle:" + angle);
            float x = center.position.x + radius * Mathf.Cos(angle);
            float y = center.position.y + radius * Mathf.Sin(angle);
            transform.position = new Vector3(x: x, y: y);
        }

    }
}
