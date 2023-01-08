
using UnityEngine;

public interface IPoolObject
{
    // 从对象池中取出object时调用
    void OnObjectSpawn();
}
