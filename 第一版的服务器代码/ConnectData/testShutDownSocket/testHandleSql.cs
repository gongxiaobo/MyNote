using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
/// <summary>
/// 测试数据库操作
/// </summary>
class testHandleSql
{
    string t_connect = "server=localhost;user=root;port=3306;password=7410;database=gong;charset=utf8;";
    MySqlConnection t_connection_read;
    MySqlConnection t_connection_write;
    public void fn_open_connect() {
        if (t_connection_read==null)
        {
            t_connection_read = new MySqlConnection(t_connect);
            t_connection_read.Open();
        }
        if (t_connection_write==null)
        {
            t_connection_write = new MySqlConnection(t_connect);
            t_connection_write.Open();
        }
     

    }
    public void fn_close_connect() {
        if (t_connection_read!=null)
        {
            t_connection_read.Close();
        }
        if (t_connection_write != null)
        {
            t_connection_write.Close();
        }
    }

    public void fn_read() {

        try
        {
          




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
            //Console.WriteLine(ex.ToString());
        }
        finally
        {
            //t_ct.Close();
        }
    
    }

    public void fn_addUser() {
        MySqlCommand t_cmdRead = new MySqlCommand("", t_connection_read);
        MySqlCommand t_cmdWrite = new MySqlCommand("", t_connection_write);
        try
        {
            t_cmdRead.CommandText = "SELECT id FROM  xian_user_1 WHERE  studentID='123468' ";
            //
            //
            using (MySqlDataReader t_reader = t_cmdRead.ExecuteReader())
            {
                //int t_haveSomeID = t_cmd.ExecuteNonQuery();
                if (t_reader.Read())
                {
                    Console.WriteLine("请求插入的学号有相同的学号");
                }
                else
                {
                    //没有相同的字段才开始写入
                    t_cmdWrite.CommandText = "INSERT INTO xian_user_1(studentID,name,password) VALUES('123468','小小68','12345678')" ;
                    int t_result = t_cmdWrite.ExecuteNonQuery();
                    if (t_result > 0)
                    {
                        Console.WriteLine("没有相同的学号,插入成功="+t_result);
                       

                    }
                }
            }

            //
            //t_cmdRead.CommandText = "SELECT id FROM  xian_user_1 WHERE  studentID='123463'";
            ////
            ////
            //using (MySqlDataReader t_getID = t_cmdRead.ExecuteReader())
            //{
            //    //uint t_id = t_getID.Read()[0];
            //    if (t_getID.Read())
            //    {
            //        uint t_getIDvalue = t_getID.GetUInt32(0);
            //        Console.WriteLine("请求插入的学生id=" + t_getIDvalue);
            //    }
            //}
            //
            t_cmdWrite.CommandText = "select max(id) from xian_user_1";
            t_cmdWrite.ExecuteNonQuery();
            object t_value = t_cmdWrite.ExecuteScalar();
            Console.WriteLine("最后插入id=" + (uint)t_value);
            //
            //using (MySqlDataReader t_getID = t_cmdWrite.ExecuteReader())
            //{
            //    if (t_getID!=null)
            //    {
            //        Console.WriteLine("最后插入id=" + t_getID[0].ToString());
            //    }
               
            //}
           
           
            //
            //using (MySqlDataReader t_getID = t_cmdRead.ExecuteScalar())
            //{
            //    //uint t_id = t_getID.Read()[0];
            //    if (t_getID.Read())
            //    {
            //        uint t_getIDvalue = t_getID.GetUInt32(0);
            //        Console.WriteLine("最后插入id=" + t_getIDvalue);
            //    }
            //}


        }
        catch (Exception ex)
        {

            throw;
        }
        finally {
            //t_cmdRead.Cancel();
            t_cmdRead.Dispose();
            //t_cmdWrite.Cancel();
            t_cmdWrite.Dispose();
        
        }
       
    }





}

