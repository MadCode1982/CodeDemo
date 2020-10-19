using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.SingletonPattern
{
    /// <summary>
    /// 饿汉模式单例
    /// </summary>
    public class HungrySingleton
    {
        /// <summary>
        /// 静态实例
        /// </summary>
        public static HungrySingleton Instance { get; } = new HungrySingleton();

        private HungrySingleton()
        {

        }

    }
}
