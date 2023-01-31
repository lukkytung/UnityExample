using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        // 移动
        transform.position -= Vector3.forward * speed * Time.deltaTime;
        // 如果敌机超出摄像头位置，销毁
        if (transform.position.z < -30)
        {
            // 销毁自身
            Destroy(gameObject);
        }
    }
    // 被子弹击中，销毁
    private void OnTriggerEnter(Collider other)
    {
        // 如果碰到子弹
        if (other.tag == "Bullet")
        {
            // 销毁自身
            Destroy(gameObject);  
        }
    }
}
