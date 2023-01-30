using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    // 导航代理
    private NavMeshAgent agent;
    // 目标点
    private Vector3 targetPos;
    // 是否到达目标点
    private bool isArrived = false;

    void Start()
    {
        // 获取导航代理组件
        agent = GetComponent<NavMeshAgent>();
        // 获取目标点
        targetPos = transform.position + new Vector3(0,0,10);
        // 向目标点移动
        agent.SetDestination(targetPos);
        Debug.Log("开始向目标移动");
        
    }

    void Update()
    {   
        // 目标点的距离
        float dis = Vector3.Distance(transform.position,targetPos);
        Debug.Log("离目标点距离："+dis);
        // 如果到达目标点
        if (dis < 0.3f)
        {
            // 重新指定一个新的目标点
            if (isArrived)
            {
                Debug.Log("向前移动+++++++++++++");
                // 到达目标点
                isArrived = false;
                // 设置目标位置
                targetPos = transform.position + new Vector3(0,0,10);
            } else
            {
                Debug.Log("向后移动--------------");
                isArrived = true;
                // 设置目标点向前移动
                targetPos = transform.position - new Vector3(0,0,10);
            }
            // 项目标点移动
            agent.SetDestination(targetPos);
        }
        
    }
}
