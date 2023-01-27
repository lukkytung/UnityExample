using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 外观模式
namespace FacadeMode
{

    public class StudentSystem
    {
        public void Run()
        {
            Debug.Log("我是学生系统");
        }
    }

    public class TeacherSystem
    {
        public void Run()
        {
            Debug.Log("我是老师系统");
        }
    }

    public class WorkerSystem
    {
        public void Run()
        {
            Debug.Log("我是工人系统");
        }
    }
    // 创建外观管理类
    public class Facade 
    {
        // 3个系统
        StudentSystem studentSystem;
        TeacherSystem teacherSystem;
        WorkerSystem workerSystem;
        public Facade()
        {
            // 初始化3个系统
            studentSystem = new StudentSystem();
            teacherSystem = new TeacherSystem();
            workerSystem = new WorkerSystem();
        }
        // 将子系统方法进行封装
        public void StudentRun()
        {
            studentSystem.Run();
        }
        public void TeacherRun()
        {
            teacherSystem.Run();
        }
        public void WorkerRun()
        {
            workerSystem.Run();
        }
    }


    public class FacadeModeTest : MonoBehaviour
    {
        void Start()
        {
            // 创建外观类
            Facade facade = new Facade();
            facade.StudentRun();
            facade.TeacherRun();
            facade.WorkerRun();
        }

    }
}

