using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C#常用类单例
namespace Singleton
{
    public class Worker
    {
        // 员工姓名
        public string Name;
    }

    public class Leader
    {
        // 唯一的领导对象
        private static Leader instance = null;
        // 员工数组
        private List<Worker> workers = new List<Worker>();
        // 给外界开放一个接口，用于访问唯一的领导对象
        public static Leader Instance
        {
            get
            {
                // 如果还没有领导对象，实例化一个领导对象
                if (instance == null)
                {
                    instance = new Leader();
                }
                return instance;
            }
        }
        // 私有化构造方法，防止外部实例化对象
        private Leader() { }
        public void AddWorker(string WorkerName)
        {
            // 创建一个员工对象
            Worker worker = new Worker();
            // 设置员工名称
            worker.Name = WorkerName;
            // 将员工添加到员工数组
            workers.Add(worker);
        }
        // 查看员工
        public void Check()
        {
            foreach (Worker worker in workers)
            {
                Debug.Log(worker.Name);
            }
        }


    }

    public class SingletonTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            funcA();
            funcB();
        }

        // 添加员工
        private void funcA()
        {
            Leader.Instance.AddWorker("员工A");
            Leader.Instance.AddWorker("员工B");
        }

        // 查看员工
        private void funcB()
        {
            Leader.Instance.Check();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

