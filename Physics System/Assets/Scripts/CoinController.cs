using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 判断触发的是不是玩家
        if (other.tag == "Player")
        {
            // 增加一枚金币
            other.GetComponent<LabyrinthPlayerController>().AddCoin();
            // 删除自己
            Destroy(gameObject);
        }
    }
}
