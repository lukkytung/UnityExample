using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 子弹预设体
    public GameObject BulletPre;
    // 子弹发射位置
    private Transform firePoint;

    public float speed = 10f;
    public float limit = 10f;

    private void Start()
    {
        // 获取子弹发射位置
        firePoint = transform.Find("FirePoint");
    }

    void Update()
    {
        // 横向飞行
        float horizontal = Input.GetAxis("Horizontal");
        // 如果不为0，证明已按下左右键
        if (horizontal != 0)
        {
            // 移动
            transform.position -= Vector3.left * speed * Time.deltaTime * horizontal;
            // 左右移动的限制
            if (transform.position.x < -limit || transform.position.x > limit)
            {
                // 复原
                transform.position += Vector3.left * speed * Time.deltaTime * horizontal;
            }
        }
        // 纵向飞行
        float vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            // 移动
            transform.position += Vector3.up * speed * Time.deltaTime * vertical;
            // 上下移动的限制
            if (transform.position.y < -limit || transform.position.y > limit)
            {
                // 复原
                transform.position -= Vector3.up * speed * Time.deltaTime * vertical;
            }
        }

        // 按下空格键发射子弹
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPre,firePoint.position,firePoint.rotation);
        }
    }

    // 如果发生碰撞
    private void OnCollisionEnter(Collision other)
    {
        // 游戏结束
        Debug.Log("游戏结束");
        // 游戏停止
        Time.timeScale = 0;
    }
}
