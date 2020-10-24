using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.FactoryMethodPattern
{
    public interface ICarFactory
    {
        public ICar CreateCar();
    }
}
