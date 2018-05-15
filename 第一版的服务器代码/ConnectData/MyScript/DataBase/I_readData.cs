using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
/// <summary>
/// 读取数据接口
/// </summary>
interface I_readData
{
    /// <summary>
    /// 根据命令，读取数据
    /// </summary>
    /// <param name="_cmd"></param>
    /// <returns></returns>
    MySqlDataReader fni_read(string _cmd);

}

