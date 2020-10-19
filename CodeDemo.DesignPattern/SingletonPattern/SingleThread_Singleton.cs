using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.SingletonPattern
{
    /// <summary>
    /// 单线程单例模式
    /// </summary>
    public class SingleThreadSingleton
    {
        /// <summary>
        /// 静态实例
        /// </summary>
        private static SingleThreadSingleton _instance = null;
        private SingleThreadSingleton() { }
        /// <summary>
        /// 获取实例
        /// </summary>
        public static SingleThreadSingleton Instance => _instance ??= new SingleThreadSingleton();
    }

    //以上代码在单线程情况下不会出现任何问题。但是在多线程的情况下却不是安全的。
    //如两个线程同时运行到 if (instance == null)判断是否被实例化，一个线程判断为True后，在进行创建
    //instance = new SingleThread_Singleton(); 之前，另一个线程也判断(instance == null)，结果也为True.
    //这样就就违背了Singleton模式的原则（保证一个类仅有一个实例）。


}
