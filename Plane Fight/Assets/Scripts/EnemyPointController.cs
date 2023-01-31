using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointController : MonoBehaviour
{
    // 关联敌机预设体
    public GameObject EnemyPre;
    // 计时器
    private float timer = 0;
    // 生成敌机的时间间隙
    private float cd = 1;
    void Update()
    {
        // 计时器
        timer += Time.deltaTime;
        // 如果计时器到时
        if (timer > cd)
        {
            // 重置计时器
            timer = 0;
            // 随机一个cd
            cd = Random.Range(0.3f, 3f);
            // 随机敌机起始位置
            Vector3 pos = transform.position + Vector3.left * Random.Range(-10f, 10f) + Vector3.up * Random.Range(-10f, 10f);
            // 实例化敌机
            Instantiate(EnemyPre,pos,transform.rotation);
        }

    }
}
