using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript.Messages
//{
/// <summary>
/// 第一次握手的反馈
/// </summary>
    class N_msg_helloToServer_back : A_baseMsg
    {
        /// <summary>
        /// true:链接成功
        /// </summary>
        public bool m_isConnected;
        public N_msg_helloToServer_back() { }
        public N_msg_helloToServer_back(bool _bl) {
            m_msgName = this.GetType().ToString();
            m_isConnected = _bl;
        }
    }
//}
