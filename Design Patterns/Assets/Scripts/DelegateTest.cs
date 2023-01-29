using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Person
    {
        // 声明委托类型
        public delegate void DoSomething();

        public delegate void AddDelegate(int a, int b);

        public void Add(AddDelegate addDelegate)
        {
            addDelegate(4, 5);
        }

        public void Run(DoSomething doSomething)
        {
            doSomething();
        }
    }

    public class Program
    {
        public static void Eat()
        {
            Debug.Log("吃饭");
        }
        public static void Play()
        {
            Debug.Log("玩耍");
        }
    }

    public class DelegateTest : MonoBehaviour
    {
        void Start()
        {
            Person person = new Person();
            Person.DoSomething doSomething;
            doSomething = Program.Eat;
            doSomething += Program.Play;
            // 匿名函数
            doSomething += delegate ()
            {
                Debug.Log("踢球");
            };
            doSomething += () =>
            {
                Debug.Log("玩手机");
            };

            person.Add((a, b) =>
            {
                int sum = a+b;
                Debug.Log("sum:" + sum);
            });

            person.Run(() =>
            {
                Debug.Log("看电视");
            });

            person.Run(doSomething);
        }

    }

}

