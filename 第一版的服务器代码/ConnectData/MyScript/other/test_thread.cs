using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//namespace ConnectData.MyScript
//{

class test_thread
    {

        private static readonly object m_locker = new object();
        private bool m_shutdown = false;
        public void fn_do01() {

            while (m_shutdown==false)
            {
                //Thread.Sleep(10);
                if (m_shutdown==false)
                {
                    Console.WriteLine("fn_do01.....");
                }
               
            }
        }

        public void fn_do02() {

            Task t_tk = new Task(() => { fn_do03(); });
            t_tk.Start();
            while (m_shutdown == false)
            {
                //Thread.Sleep(10);
                if (m_shutdown==false)
                {
                    Console.WriteLine("fn_do02.....");
                }
              
            }
        
        }
        private bool m_shutdown1 = false;
        public bool M_shutdown1 { get {
            lock (m_locker)
            {
                return m_shutdown1;
            }

        }
            set
            {
                lock (m_locker) { m_shutdown1 = value; }
              
            }
        }
        private Mutex m_mutex=new Mutex();
        public void fn_do03() {
            while (M_shutdown1==false)
            {
                Thread.Sleep(2);
                //m_mutex.WaitOne();
                    if (M_shutdown1 == false)
                    {
                        Console.WriteLine("fn_do03.....");
                    }
                              
                
            }
        }

        public void fn_close() {
            m_shutdown = true;
        }
        public void fn_close1() {
            //lock (m_locker)
            //{
            M_shutdown1 = true;
                //m_shutdown1 = true;
            //}
           

        }

        

    }
//}
