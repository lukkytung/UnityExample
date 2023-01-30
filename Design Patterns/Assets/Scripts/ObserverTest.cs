using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    // 观众接口
    public interface Viewer
    {
        void Run();
    }
    // 观众A
    public class ViewerA : Viewer
    {
        public void Run()
        {
            Debug.Log("大笑");
        }
    }

    // 观众B
    public class ViewerB : Viewer
    {
        public void Run()
        {
            Debug.Log("大哭");
        }
    }

    // 观众C
    public class ViewerC : Viewer
    {
        public void Run()
        {
            Debug.Log("关掉电视");
        }
    }

    public class TV
    {
        // 监听的观众
        public List<Viewer> viewers = new List<Viewer>();
        // 添加观察者
        public void Add(Viewer viewer)
        {
            viewers.Add(viewer);
        }
        // 移除观察者
        public void Remove(Viewer viewer)
        {
            viewers.Remove(viewer);
        }
        // 调用观察者的方法
        public void Run()
        {
            foreach (Viewer viewer in viewers)
            {
                viewer.Run();
            }
        }
    }

    public class ObserverTest : MonoBehaviour
    {
        TV tv;

        void Start()
        {
            tv = new TV();
            tv.Add(new ViewerA());
            tv.Add(new ViewerB());
            tv.Add(new ViewerC());
        }

        void Update()
        {
            // 单击鼠标左键，让TV类发送一条消息。
            // 观众们监听到消息后各自执行自己的方法
            if (Input.GetMouseButtonDown(0))
            {
                tv.Run();
            }
        }
    }

}
