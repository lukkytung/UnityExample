using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public String groundTag;

    ObjectPool objectPool;
    private Transform cameraTr;
    private Transform playerTr;

    void Start()
    {
        cameraTr = GameObject.FindWithTag("MainCamera").transform;
        playerTr = GameObject.FindWithTag("Player").transform;
        objectPool = ObjectPool.instance;

    }

    private void Update()
    {
       Vector3 forward = cameraTr.forward;
        // if (Vector3.Distance(cameraTr.position, transform.position) > 10 && playerTr.position.z > transform.position.z)
        // {
        //     // 回收地板
        //     objectPool.EnqueueObject(groundTag, gameObject);
        // }
        if (cameraTr.position.z - transform.position.z > 10 )
        {
            // 回收地板
            objectPool.EnqueueObject(groundTag, gameObject);
        }

        // if (groundTag == "LeftRight")
        // {
        //     if (cameraTr.position.x - transform.position.x > 10)
        //     {
        //         // 回收地板
        //         objectPool.EnqueueObject(groundTag, gameObject);
        //     }
        // }
        // else if (groundTag == "RightLeft")
        // {
        //     if (cameraTr.position.x - transform.position.x < -10)
        //     {
        //         // 回收地板
        //         objectPool.EnqueueObject(groundTag, gameObject);
        //     }
        // }
        // else
        // {
        //     if (cameraTr.position.z - transform.position.z > 10)
        //     {
        //         // 回收地板
        //         objectPool.EnqueueObject(groundTag, gameObject);
        //     }
        // }
    }
}
