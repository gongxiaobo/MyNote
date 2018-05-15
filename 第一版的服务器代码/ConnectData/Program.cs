using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;

//using MySql.Data;
//using MySql.Data.MySqlClient;

using LitJson;
using ConnectData.MyScript;

using System.Net;
using System.Net.Sockets;


namespace ConnectData
{
    class Program
    {
        static void Main(string[] args)
        {
            //S_sql.M_instance.fn_open_connect();
            ServerTest t_server = new ServerTest();
            t_server.fn_startServer();
            S_sql.M_instance.fn_open_connect();

            //ConnectMysql t_mysql = new ConnectMysql();
            //t_mysql.fn_connectMysql();
            //ClientTest t_clienttest = new ClientTest();
            //t_clienttest.fn_startClient();

       
            //if (Console.ReadKey().Key == ConsoleKey.Q)
            //{
            //    Console.WriteLine("按下 Q 键");
            //    //t_testThread.fn_close();
            //    t_server.fn_closeServer();
            //}

            //if (Console.ReadKey().Key == ConsoleKey.E)
            //{
            //    Console.WriteLine("按下 E键");
            //    //t_testThread.fn_close1();
            //    t_server.fn_closeServer();
            //}

            //testShutdownSocket t_shutdownsocket = new testShutdownSocket();
            //if (Console.ReadKey().Key == ConsoleKey.S)
            //{
            //    Console.WriteLine("按下 S键");
            //    t_shutdownsocket.fn_startServer();
            //}

            //
            //testHandleSql t_testSql = new testHandleSql();
            //t_testSql.fn_open_connect();
            //t_testSql.fn_addUser();
            //t_testSql.fn_addUser();
            //
          
            //string t_check = S_makeCmd.fns_readCmd1(
            //    "xian_user_1",
            //    "studentID", "123477");
            //string t_insert = S_makeCmd.fns_insert3(
            //    "xian_user_1",
            //    "studentID", "123477",
            //    "name", "小小77",
            //    "password", "12345679");
            ////uint t_insertid = S_sql.M_instance.fn_insert(t_insert, "xian_user_1");
            //if (S_sql.M_instance.fn_read(t_check)==false)
            //{
            //    uint t_insertid01 = S_sql.M_instance.fn_insert(t_insert, "xian_user_1");
            //    Console.WriteLine("插入到id=" + t_insertid01);
            //}
            //else {
            //    Console.WriteLine("有相同的学号");
            //}
            //if (Console.ReadKey().Key == ConsoleKey.Escape)
            //{
            //    S_sql.M_instance.fn_close_connect();
            //    t_server.fn_closeServer();
            //}

            //new Task(() => {
            //    fn_do1();
            //}).Start();

            //ThreadPool.QueueUserWorkItem(
            //    (m)=>Console.WriteLine(m),"xxxy");

            //ThreadPool.QueueUserWorkItem(
            //    //(m) => Console.WriteLine(m)
            // (m) => { Console.WriteLine(m+"skdjflsk01"); }
            // ,"m=");
            


            Console.ReadKey();

        }
      
    
        static readonly object m_locker = new object();
        public static void fn_do1() {
            Console.WriteLine("fn_do1--->");
            Task t_task= new Task(() =>
            {
                fn_do2("xx");
            });
            t_task.Start();
            Task t_task01 = new Task(() =>
            {
                fn_do2("-----yy");
            });
            t_task01.Start();
            t_task.Wait();
            t_task01.Wait();
            Console.WriteLine("fn_do1 finish, t_task state="+t_task.Status);
            Console.WriteLine("fn_do1 finish, t_task01 state=" + t_task01.Status);
        }
        public static void fn_do2(string _str) {



            fn_do3(_str);
            //int t_int = 20;
            //while (t_int > 0) {
            //    Thread.Sleep(100);
            //    t_int--;
            //    Console.WriteLine("fn_do2>" + _str);
            
            //}
            //Console.WriteLine("fn_do2 finish :" + _str);
        }

        public static void fn_do3(string _str)
        {
            int t_int01 = 20;
            while (t_int01 > 0)
            {
                Thread.Sleep(100);
             
                Console.WriteLine("fn_do2>" + _str+"@="+t_int01);
                t_int01--;

            }
            Console.WriteLine("fn_do2 finish:"+_str);
         
        }
 
    }
}
