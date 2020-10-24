using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.AbstractFactoryPattern
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public interface IAbstractFactory
    {
        public IAbstractProductA CreateProductA();

        public IAbstractProductB CreateProductB();
    }
}
