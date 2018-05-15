using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 学员退出
/// </summary>
 class N_msg_studentExit : N_msg_userExit
{
    /// <summary>
    /// 学号
    /// </summary>
    public string m_studentID;
    public N_msg_studentExit()
    {
    }
    //public N_msg_studentExit(string _macID, string _studentID)
    //{
    //    m_msgName = this.GetType().ToString();
    //    m_username = _macID;
    //    m_studentID = _studentID;
    //}
}
