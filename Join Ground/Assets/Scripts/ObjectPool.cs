using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    // 对象池类
    public class Pool
    {
        // 标签
        public string tag;
        // 预制件
        public GameObject prefab;
        // 数量
        public int size;
    }
    // 本组件单例对象
    public static ObjectPool instance;
    #region 组件单例化
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // 从预制件中初始化物体
                GameObject obj = Instantiate(pool.prefab);
                // 物体设置为非激活状态
                obj.SetActive(false);
                // 把物体放进队列
                objectPool.Enqueue(obj);
            }
            // 字典保存队列
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    /// <summary>
    /// 从对象池中取出物体
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        // 如果字典中没有该tag的对象，则打印警告
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("对象池中不存在标识为：" + tag + "物体");
            return null;
        }
        // 从对象池中取出物体
        GameObject objectFromSpawn = poolDictionary[tag].Dequeue(); 
        objectFromSpawn.SetActive(true);
        objectFromSpawn.transform.position = position;
        objectFromSpawn.transform.rotation = rotation;
        return objectFromSpawn;
    }
    /// <summary>
    /// 把物体放回对象池
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="gameObject"></param>
    public void EnqueueObject(string tag, GameObject gameObject)
    {
        gameObject.SetActive(false);
        // 将物体放回对象池
        poolDictionary[tag].Enqueue(gameObject);
    }

}