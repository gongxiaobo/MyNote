using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript.Messages
//{
/// <summary>
/// 学员登陆信息
/// </summary>
class N_msg_userload : A_baseMsg
{
    public  string m_username;
    public  string m_password;
    //机器名称ID
    public string m_machineID;
    //public N_msg_userload(string _username, string _password)
    //{
    //    m_msgName = this.GetType().ToString();
    //    m_username = _username;
    //    m_password = _password;
    //}
    public N_msg_userload()
    {
    }
}
//}
