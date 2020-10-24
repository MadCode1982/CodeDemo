using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.FactoryMethodPattern
{
    public interface ICar
    {
        public string Name { get; set; }
        public void Run();
    }
}
