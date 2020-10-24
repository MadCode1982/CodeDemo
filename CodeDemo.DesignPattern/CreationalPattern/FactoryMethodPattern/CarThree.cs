using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.FactoryMethodPattern
{
    public class CarThree : ICar
    {
        public string Name { get; set; } = "三轮车";

        public void Run()
        {
            Console.WriteLine(this.Name + "在跑！");
        }
    }
}
