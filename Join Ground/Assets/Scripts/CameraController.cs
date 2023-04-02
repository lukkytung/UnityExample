using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target; // 摄像机跟随的目标

    public float distance = 10.0f;
    public float height = 5.0f;
    public float damping = 2.0f;
    public float rotationDamping = 3.0f;

    private void LateUpdate()
    {
        if (target)
        {
            // 计算摄像机的位置
            Vector3 wantedPosition = target.TransformPoint(0, height, -distance);

            // 移动摄像机位置
            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

            // 计算摄像机的旋转角度
            float wantedRotationAngle = target.eulerAngles.y;
            float currentRotationAngle = transform.eulerAngles.y;
            float rotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, Time.deltaTime * rotationDamping);

            // 旋转摄像机
            Quaternion currentRotation = Quaternion.Euler(transform.eulerAngles.x, rotationAngle, 0);
            transform.position = target.position - (currentRotation * Vector3.forward * distance);

            transform.LookAt(target);
        }
    }
}
