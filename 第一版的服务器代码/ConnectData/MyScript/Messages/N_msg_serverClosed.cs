using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript.Messages
//{
/// <summary>
/// 服务器关闭消息
/// </summary>
    class N_msg_serverClosed : A_baseMsg
    {
        /// <summary>
        /// true:关闭
        /// </summary>
        public bool m_serverClose;
        public N_msg_serverClosed() { }
        public N_msg_serverClosed(bool _bl) {
            m_msgName = this.GetType().ToString();
            m_serverClose = _bl;
        }
    }
//}
