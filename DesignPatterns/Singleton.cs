using System.Runtime.CompilerServices;

namespace DesignPatterns
{
    /// <summary>
    /// 经典的单例模式实现
    /// </summary>
    public class Singleton_Classic
    {
        //全局唯一
        private static Singleton_Classic uniqueInstance;

        //私有构造函数
        private Singleton_Classic() { }

        //得到该对象的方法
        public static Singleton_Classic GetInstance()
        {
            //延迟实例化
            if (uniqueInstance == null)
            {
                uniqueInstance = new Singleton_Classic();
            }

            return uniqueInstance;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Singleton_Classic UniqueInstance
        {
            get
            {
                return uniqueInstance ?? (uniqueInstance = new Singleton_Classic());
            }
        }
    }

    /// <summary>
    /// 线程安全的单例实现一
    /// </summary>
    public class Singleton_Synchronized
    {
        //全局唯一
        private static Singleton_Synchronized uniqueInstance;

        //私有构造函数
        private Singleton_Synchronized() { }

        //得到该对象的方法，synchronized拖效率
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Singleton_Synchronized GetInstance()
        {
            //延迟实例化
            if (uniqueInstance == null)
            {
                uniqueInstance = new Singleton_Synchronized();
            }

            return uniqueInstance;
        }
    }

    /// <summary>
    /// 线程安全的单例实现二
    /// </summary>
    public class Singleton_Lock
    {
        //全局唯一
        private static Singleton_Lock uniqueInstance;
        //进程辅助对象
        private static readonly object locker = new object();

        //私有构造函数
        private Singleton_Lock() { }

        //得到该对象
        public static Singleton_Lock GetInstance()
        {
            lock (locker)
            {
                if (uniqueInstance == null)
                {
                    uniqueInstance = new Singleton_Lock();
                }
            }

            return uniqueInstance;
        }
    }

    /// <summary>
    /// 线程安全的单例实现三
    /// 双重检查加锁
    /// </summary>
    public class Singleton_DoubleCheckedLocking
    {
        //全局唯一
        private static Singleton_DoubleCheckedLocking uniqueInstance;
        // Creates an syn object
        private static readonly object locker = new object();

        //私有构造函数
        private Singleton_DoubleCheckedLocking() { }

        //得到该对象
        public static Singleton_DoubleCheckedLocking GetInstance()
        {
            //Double-Checked Locking implements a thread-safe singleton class
            //java中的写法是synchronized(Singleton.class){}，同时配上volatile的成员
            //C# volatile修饰符通常用于由多个线程访问但不使用 lock 语句对访问进行序列化的字段
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    //延迟实例化
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton_DoubleCheckedLocking();
                    }
                }
            }

            return uniqueInstance;
        }
    }

    /// <summary>
    /// 急切实例化
    /// </summary>
    public class Singleton_Eagerly
    {
        //全局唯一，线程安全
        private static Singleton_Eagerly uniqueInstance = new Singleton_Eagerly();

        //私有构造函数
        private Singleton_Eagerly() { }

        //得到该对象
        public static Singleton_Eagerly GetInstance()
        {
            return uniqueInstance;
        }
    }
}

