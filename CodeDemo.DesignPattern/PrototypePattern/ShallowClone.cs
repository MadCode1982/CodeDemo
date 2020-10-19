using System;
using System.Collections.Generic;
using System.Text;
using CodeDemo.DesignPattern.SingletonPattern;

namespace CodeDemo.DesignPattern.PrototypePattern
{
    /// <summary>
    /// 浅克隆
    /// </summary>
    public class ShallowClone
    {
        /// <summary>
        /// 浅克隆
        /// </summary>
        /// <returns></returns>
        public object ShallowCloneObj()
        {
            return this.MemberwiseClone();
        }
    }
}
