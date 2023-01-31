using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Start()
    {
        // 5秒后销毁
        Destroy(gameObject,5f);
        // 飞行速度
        GetComponent<Rigidbody>().velocity = Vector3.forward * 50f;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 触发后销毁
        Destroy(gameObject);
    }
}
