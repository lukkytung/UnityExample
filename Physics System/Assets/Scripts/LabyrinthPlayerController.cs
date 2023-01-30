using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthPlayerController : MonoBehaviour
{

    // 刚体
    private new Rigidbody rigidbody;
    // 吃到的金币个数
    private int coinCount;
    // 移动速度
    public float speed = 30f;

    void Start()
    {
        // 获取组件刚体
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 获取水平轴数值
        float horizontal = Input.GetAxis("Horizontal");
        // 获取垂直轴数值
        float vertical = Input.GetAxis("Vertical");
        // 移动方向向量
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        // 如果向量存在，证明按下了方向键
        if (dir != Vector3.zero)
        {
            // 转向该向量
            transform.rotation = Quaternion.LookRotation(dir);
            // 向前方移动
            rigidbody.velocity = dir.normalized * speed * Time.deltaTime;
        }
        else
        {
            // 停止移动
            rigidbody.velocity = Vector3.zero;
        }
    }
    // 碰撞检测
    private void OnCollisionEnter(Collision other)
    {
        // 如果碰撞到的是墙壁
        if (other.collider.tag == "Wall")
        {
            // 游戏结束
            Debug.Log("游戏失败，结束");
            // 游戏停止
            Time.timeScale = 0;
        }
    }

    // 增加金币方法
    public void AddCoin()
    {
        // 增加一枚金币
        coinCount++;
        if (coinCount >= 3)
        {
            // 游戏胜利
            Debug.Log("游戏胜利，结束");
            // 游戏停止
            Time.timeScale = 0;
        }
    }
}
