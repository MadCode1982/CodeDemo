using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.FactoryMethodPattern
{
    public class ThreeCarFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return  new CarThree();
        }
    }
}
