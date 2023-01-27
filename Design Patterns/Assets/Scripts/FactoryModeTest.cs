using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 工厂模式
namespace FactoryMode
{
    //汽车抽象类
    public abstract class Car
    {
        public abstract void Run();
    }
    public class Bmw : Car
    {
        public override void Run()
        {
            Debug.Log("宝马");
        }
    }
    public class Benz : Car
    {
        public override void Run()
        {
            Debug.Log("奔驰");
        }
    }
    public class Audi : Car
    {
        public override void Run()
        {
            Debug.Log("奥迪");
        }
    }
    // 汽车类型
    public enum CarType
    {
        Bmw,
        Benz,
        Audi,
    }
    // 工厂类
    public class Factory
    {
        public static Car Create(CarType type)
        {
            Car car = null;
            switch (type)
            {
                case CarType.Bmw:
                    car = new Bmw();
                    break;
                case CarType.Benz:
                    car = new Benz();
                    break;
                case CarType.Audi:
                    car = new Audi();
                    break;
            }
            return car;
        }
    }
    public class FactoryModeTest : MonoBehaviour
    {
        void Start()
        {
            Car bmw = Factory.Create(CarType.Bmw);
            bmw.Run();
            Car benz = Factory.Create(CarType.Benz);
            benz.Run();
        }

    }

}

