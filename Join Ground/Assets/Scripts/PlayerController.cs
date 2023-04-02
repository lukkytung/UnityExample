using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody rb;
    private Transform target;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        target = GetComponent<Transform>();

    }

    private void FixedUpdate()
    {

        // 获取物体当前的前方向向量
        Vector3 forward = transform.forward;

        rb.velocity = forward * speed;
        // rb.MovePosition(forward * speed * Time.deltaTime);

        //给刚体施加一个力，使物体向前移动
        // rb.AddForce(forward * speed * Time.deltaTime, ForceMode.Impulse);
        // rb.AddForce(new Vector3(0,0,speed),ForceMode.Force);
    }
}
