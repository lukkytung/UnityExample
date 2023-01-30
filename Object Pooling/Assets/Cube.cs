using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPoolObject
{
    // 向上的力
    public float upForce = 1f;
    // 左右的力
    public float sideForce = .1f;

    public void OnObjectSpawn()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3(xForce, yForce, zForce);
        
        GetComponent<Rigidbody>().velocity = force;
    }
}
