using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 抽象类的应用
namespace StateTest
{

    // 抽象状态类，继承该类需要实现抽象类中的方法
    public abstract class State
    {
        public abstract void Run();
    }

    // 睡觉状态类
    public class SleepState : State
    {
        public override void Run()
        {
            Debug.Log("睡觉状态的执行代码");
        }
    }
    // 玩状态类
    public class PlayState : State
    {
        public override void Run()
        {
            Debug.Log("玩儿状态的执行代码");
        }
    }
    // 学习状态类
    public class StudyState : State
    {
        public override void Run()
        {
            Debug.Log("学习状态的执行代码");
        }
    }
    // 学生类
    public class Student
    {
        // 每名学生都有一个当前状态
        public State state;

        public void Run(int time)
        {
            if (time > 21 || time < 7)
            {
                state = new SleepState();
            }
            else if (time >= 7 && time <= 18)
            {
                state = new StudyState();
            }
            else
            {
                state = new PlayState();
            }
            state.Run();
        }
    }


    public class StateModeTest : MonoBehaviour
    {
        void Start()
        {
            // 实例化学生对象
            Student student = new Student();
            // 18点的状态
            student.Run(20);
            // 23点的状态
            student.Run(23);
        }

    }

}


