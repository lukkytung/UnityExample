using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    // 前轮数组
    public WheelCollider[] frontWheels;
    // 后轮数组
    public WheelCollider[] backWheels;

    void Update()
    {
        // 获取水平轴
        float horizontal = Input.GetAxis("Horizontal");
        // 获取垂直轴
        float vertical = Input.GetAxis("Vertical");
        // 遍历前轮
        foreach (WheelCollider wheel in frontWheels)
        {
            // 最大转弯角度30
            wheel.steerAngle = horizontal * 30;
            // wheel.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, horizontal * 30, 90));
        }
        // 遍历后轮
        foreach (WheelCollider wheel in backWheels)
        {
            // 最大马力200
            wheel.motorTorque = vertical * 200;
        }
    }
}
