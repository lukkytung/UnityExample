using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity组件类单例
public class ComponentSingleton : MonoBehaviour
{
    public static ComponentSingleton Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
}
