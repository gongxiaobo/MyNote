using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 返回记录表的id
/// s to c 
/// </summary>
class N_msg_reordID : A_baseMsg
{
    /// <summary>
    /// 表中的id
    /// </summary>
    public uint m_id;
    /// <summary>
    /// 表名
    /// </summary>
    public string m_tableName;

    public N_msg_reordID() { }
    public N_msg_reordID(uint _id,string _tableName) {
        m_msgName = this.GetType().ToString();
        m_id = _id;
        m_tableName = _tableName;
    }

}

