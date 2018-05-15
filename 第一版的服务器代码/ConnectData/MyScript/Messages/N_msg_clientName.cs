using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript.Messages
//{
/// <summary>
/// 为新加入的客服端编号
/// </summary>
    class N_msg_clientName : A_baseMsg
    {
        public string m_clientName;
        public N_msg_clientName()
        {
        }
        public N_msg_clientName(string _name) {

            m_msgName = this.GetType().ToString();
            m_clientName = _name;

        }

    }
//}
