using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public Transform target;

    public float distance = 10f;

    private GroundType groundType = GroundType.Straight;

    // 对象池
    private ObjectPool objectPool;

    /// <summary>
    /// 最新的地形位置
    /// </summary>
    private Vector3 lastPosition = Vector3.zero;

    // 初始化时随机生成直行地板数量
    private int startCount = 3;

    void Start()
    {
        startCount = Random.Range(3, 10);

        objectPool = ObjectPool.instance;
    }

    private void Update()
    {
        if (startCount > 0)
        {
            startCount--;
            CreateStraightGround();
        }
        else
        {
            if (Vector3.Distance(lastPosition, target.position) < distance)
            {

                NextGroundFromLastGroundType(groundType);
            }
        }
    }

    // 下一块地板
    void NextGroundFromLastGroundType(GroundType type)
    {
        switch (type)
        {
            case GroundType.Straight:
                StraightGroundGetNext();
                break;
            case GroundType.BottomLeft:
                BottomLeftGroundGetNext();
                break;
            case GroundType.BottomRight:
                BottomRightGroundGetNext();
                break;
            case GroundType.LeftTop:
                LeftOrRightTopGroundGetNext();
                break;
            case GroundType.RightTop:
                LeftOrRightTopGroundGetNext();
                break;
            case GroundType.LeftRight:
                LeftRightGroundGetNext();
                break;
            case GroundType.RightLeft:
                RightLeftGroundGetNext();
                break;
        }
    }

    // 从左/右向上转弯拼接下一块地板
    void LeftOrRightTopGroundGetNext()
    {
        GameObject groundObj;
        int rand = Random.Range(0, 10);
        if (rand <= 3)
        {
            // 直行
            groundObj = objectPool.SpawnFromPool("Straight", lastPosition + new Vector3(0, 0, 10), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.Straight;
        }
        else if (rand > 3 && rand <= 6)
        {
            // 左转弯
            groundObj = objectPool.SpawnFromPool("BottomLeft", lastPosition + new Vector3(0, 0, 10), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.BottomLeft;
        }
        else if (rand > 6 && rand <= 9)
        {
            // 左转弯
            groundObj = objectPool.SpawnFromPool("BottomRight", lastPosition + new Vector3(0, 0, 10), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.BottomRight;
        }
    }

    // 从直行地板获得并拼接下一块地板
    void StraightGroundGetNext()
    {
        GameObject groundObj;
        int rand = Random.Range(0, 10);
        if (rand <= 3)
        {
            // 直行
            groundObj = objectPool.SpawnFromPool("Straight", lastPosition + new Vector3(0, 0, 10), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.Straight;
        }
        else if (rand > 3 && rand <= 6)
        {
            // 左转弯
            groundObj = objectPool.SpawnFromPool("BottomLeft", lastPosition + new Vector3(0, 0, 10), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.BottomLeft;
        }
        else if (rand > 6 && rand <= 9)
        {
            // 左转弯
            groundObj = objectPool.SpawnFromPool("BottomRight", lastPosition + new Vector3(0, 0, 10), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.BottomRight;
        }
    }

    // 底部右转拼接下一块地板
    void BottomRightGroundGetNext()
    {
        GameObject groundObj;
        int rand = Random.Range(0, 6);
        if (rand <= 3)
        {
            // 从左往右：直行
            groundObj = objectPool.SpawnFromPool("LeftRight", lastPosition + new Vector3(10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.LeftRight;
        }
        else if (rand > 3)
        {
            // 从左向上转弯
            groundObj = objectPool.SpawnFromPool("LeftTop", lastPosition + new Vector3(10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.LeftTop;
        }
    }

    // 左往右拼接下一块地板
    void LeftRightGroundGetNext()
    {
        GameObject groundObj;
        int rand = Random.Range(0, 6);
        if (rand <= 3)
        {
            // 从左往右：直行
            groundObj = objectPool.SpawnFromPool("LeftRight", lastPosition + new Vector3(10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.LeftRight;
        }
        else if (rand > 3)
        {
            // 从左向上转弯
            groundObj = objectPool.SpawnFromPool("LeftTop", lastPosition + new Vector3(10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.LeftTop;
        }
    }
    // 底部左转拼接下一块地板
    void BottomLeftGroundGetNext()
    {
        GameObject groundObj;
        int rand = Random.Range(0, 6);
        if (rand <= 3)
        {
            // 从左往右：直行
            groundObj = objectPool.SpawnFromPool("RightLeft", lastPosition + new Vector3(-10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.RightLeft;
        }
        else if (rand > 3)
        {
            // 从左向上转弯
            groundObj = objectPool.SpawnFromPool("RightTop", lastPosition + new Vector3(-10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.RightTop;
        }
    }

    // 右往左直行拼接下一块地板
    void RightLeftGroundGetNext()
    {
        GameObject groundObj;
        int rand = Random.Range(0, 6);
        if (rand <= 3)
        {
            // 从右往左：直行
            groundObj = objectPool.SpawnFromPool("RightLeft", lastPosition + new Vector3(-10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.RightLeft;
        }
        else if (rand > 3)
        {
            // 从左向上转弯
            groundObj = objectPool.SpawnFromPool("RightTop", lastPosition + new Vector3(-10, 0, 0), Quaternion.identity);
            lastPosition = groundObj.transform.position;
            groundType = GroundType.RightTop;
        }
    }

    /// <summary>
    /// 从对象池中取出地形
    /// </summary>
    void CreateStraightGround()
    {

        // 如果最远的地形坐标与主角的距离小于Distance，则从对象池中取出新的地形
        // if (Vector3.Distance(lastPosition, target.position) < distance)
        // {
        GameObject groundObj;
        if (lastPosition == Vector3.zero)
        {
            // 创建第一块地形
            groundObj = objectPool.SpawnFromPool("Straight", new Vector3(0, 0, 1), Quaternion.identity);
            lastPosition = groundObj.transform.position;
        }
        else
        {
            // 下一块地形则在前一块的基础上拼接
            groundObj = objectPool.SpawnFromPool("Straight", lastPosition + new Vector3(0, 0, 10), Quaternion.identity);
            lastPosition = groundObj.transform.position;
        }
        groundType = GroundType.Straight;
        // }
    }
}
