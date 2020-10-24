using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.FactoryMethodPattern
{
    public class FourCarFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return  new CarFour();
        }
    }
}
