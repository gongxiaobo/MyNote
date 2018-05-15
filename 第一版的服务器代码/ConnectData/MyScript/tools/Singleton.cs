using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 用于多线程下单利模式的基类
/// 20170329 V1
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T>where T: new ()
{
    private static T m_instance;
    private static readonly object m_lock = new object();
    public static T M_instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_lock)
                {
                    if (m_instance == null)
                    {
                        m_instance = new T();
                    }
                }
            }

            return m_instance;
        }
    }

}

