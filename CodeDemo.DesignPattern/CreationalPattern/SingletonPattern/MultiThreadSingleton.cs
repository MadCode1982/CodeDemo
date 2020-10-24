using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.SingletonPattern
{
    /// <summary>
    /// 多线程单单例模式
    /// </summary>
    public class MultiThreadSingleton
    {
        /// <summary>
        /// 实例
        /// </summary>
        private static volatile MultiThreadSingleton _instance = null;
        /// <summary>
        /// 线程锁
        /// </summary>
        private static readonly object LockHelper = new object();

        private MultiThreadSingleton()
        {
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        public static MultiThreadSingleton Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (LockHelper)
                {
                    _instance = new MultiThreadSingleton();
                }

                return _instance;
            }
        }
        //此程序对多线程是安全的，使用了一个辅助对象lockHelper，保证只有一个线程创建实例（如果instance为空，保证只有一个线程instance = new MultiThread_Singleton();创建唯一的一个实例）。（Double Check)
        //请注意一个关键字volatile，如果去掉这个关键字，还是有可能发生线程不是安全的。
        //volatile 保证严格意义的多线程编译器在代码编译时对指令不进行微调。
    }
}