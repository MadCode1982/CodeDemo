using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.AbstractFactoryPattern
{
    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }
}
