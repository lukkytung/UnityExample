using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    private void FixedUpdate() 
    {
        objectPooler.SpawnFromPool("Cube",transform.position,Quaternion.identity);   
    }
}
