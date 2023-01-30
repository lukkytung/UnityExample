using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondPlayerController : MonoBehaviour
{
    // 导航代理组件
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Debug.Log("-----------------");

        if (Input.GetMouseButtonDown(1))
        {
            // 获取鼠标射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 碰撞信息
            RaycastHit hit;
            // 碰撞检测
            bool res = Physics.Raycast(ray, out hit);
            if (res)
            {
                Debug.Log("获取碰撞点");
                // 获取碰撞点
                Vector3 point = hit.point;
                // 导航到碰撞点
                agent.SetDestination(point);
            }
        }
    }
}
