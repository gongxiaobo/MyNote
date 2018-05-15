using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
/// <summary>
/// 链接数据库
/// </summary>
class N_connectTodata : A_connectTodata
{
    /// <summary>
    /// 链接信息
    /// </summary>
    public string m_connect = "server=localhost;user=root;port=3306;password=7410;database=gong;";
    /// <summary>
    /// 数据库的链接
    /// </summary>
    protected MySqlConnection m_sqlConnection;
    public override void fn_connect()
    {
        //链接数据库gong
        if (m_sqlConnection==null)
        {

            try
            {
                m_sqlConnection = new MySqlConnection(m_connect);
                m_sqlConnection.Open();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

        }
 
        
    }
    public override void fn_close()
    {
        if (m_sqlConnection!=null)
        {
            m_sqlConnection.Close();
            m_sqlConnection.Dispose();
            m_sqlConnection = null;
        }
        
       
    }

    private static readonly object m_lockRead = new object();
    public override MySqlDataReader fni_read(string _cmd)
    {
        lock (m_lockRead)
        {
            if (_cmd == "")
            {
                return null;
            }
            if (m_sqlConnection != null)
            {
                try
                {
                    //操作数据库命令
                    MySqlCommand t_cmd = new MySqlCommand(_cmd, m_sqlConnection);
                    //执行操作数据库命令
                    MySqlDataReader t_reader = t_cmd.ExecuteReader();
                    return t_reader;
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
                    return null;
                    //throw;
                }


            }

            return null;
        }
        
    }

}

