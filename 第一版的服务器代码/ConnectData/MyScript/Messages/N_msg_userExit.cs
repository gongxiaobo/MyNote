using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 客服端向服务器请求退出登录
/// </summary>
class N_msg_userExit : A_baseMsg
{
    /// <summary>
    /// 登陆名
    /// </summary>
    public string m_username;

}

