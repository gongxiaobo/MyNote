using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

//namespace ConnectData.MyScript
//{
    class ConnectMysql
    {
        public void fn_connectMysql() {

            //链接数据库gong
            string t_connect = "server=localhost;user=root;port=3306;password=7410;database=xian;charset=utf8;";
            MySqlConnection t_ct = new MySqlConnection(t_connect);

            try
            {
                t_ct.Open();
                //读取数据库中的类容
                string t_findID = "SELECT studentID   FROM xian_user_1 WHERE  studentID = '123521'";
                MySqlCommand t_findIDonly = new MySqlCommand(t_findID, t_ct);
                //MySqlDataReader t_reader01 = t_findIDonly.ExecuteReader();
                //if (t_reader01.Read())
                //{

                //}
                //while (t_reader01.Read())
                //{
                //    Console.WriteLine("find -->" + t_reader01[0] );
                //}
                //t_reader01.Close();
                //string t_add = "insert into xian_user_1 (studentID,name,password) values( '123535212','ahlxx','123456')";
                ////string t_add = "update  test01 set name='搞啥啥cc' where id=9";
                //MySqlCommand t_cmdadd = new MySqlCommand(t_add, t_ct);
                //if (t_cmdadd.ExecuteNonQuery() > 0)
                //{
                //    Console.WriteLine("插入成功");
                //}
               
                //string t_sql = "SELECT * FROM data_people ";
                string t_sql = "SELECT * FROM xian_user_1 ";
                //操作数据库命令
                MySqlCommand t_cmd = new MySqlCommand(t_sql, t_ct);
                //执行操作数据库命令
                MySqlDataReader t_reader = t_cmd.ExecuteReader();

                while (t_reader.Read())
                {

                    Console.WriteLine("-->" + t_reader[0] + "-->" + t_reader[1] + "-->" + t_reader[2] + "-->" + t_reader[3]);
     
                }

                t_reader.Close();

                //
                string t_sql01 = "SELECT * FROM xian_user_load_record_1 ";
                //操作数据库命令
                MySqlCommand t_cmdreord = new MySqlCommand(t_sql01, t_ct);
                //执行操作数据库命令
                MySqlDataReader t_readerecord = t_cmdreord.ExecuteReader();
                uint t_id;
                while (t_readerecord.Read())
                {
                      t_id = t_readerecord.GetUInt32(0) ;
                     Console.WriteLine("unit=" + t_id);

                    Console.WriteLine("-->" + t_id + "-->" + t_readerecord[1] + "-->" + t_readerecord[2] + "-->" + t_readerecord[3] 
                        );
                    Console.WriteLine("xxx" );

                }
                Console.WriteLine("");
                t_readerecord.Close();





            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {

                    case 0:
                        Console.WriteLine("cannot connect to server!");
                        break;
                    case 1045:
                        Console.WriteLine("invalid user name or password!");
                        break;

                }
                Console.WriteLine("访问数据库有问题");
                Console.WriteLine(ex.ToString());
            }
            finally {
                t_ct.Close();
            }
           
        
        }
    }
//}
