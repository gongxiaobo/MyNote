using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
/// <summary>
/// 用于连接数据库的抽象
/// </summary>
abstract class A_connectTodata : I_readData
{
    /// <summary>
    /// 链接数据库
    /// </summary>
    public abstract void fn_connect();
    /// <summary>
    /// 关闭，在服务器关闭时调用
    /// </summary>
    public abstract void fn_close();

    public  abstract  MySqlDataReader fni_read(string _cmd);
}

