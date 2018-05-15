using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 忘掉记录这张表的 插入数据的 id
/// </summary>
class N_msg_forgetID : A_baseMsg
{
    //表名
    public string m_tableName;
    public N_msg_forgetID() { }
    public N_msg_forgetID(string _table) {
        m_msgName = this.GetType().ToString();
        m_tableName = _table;
    }
}
