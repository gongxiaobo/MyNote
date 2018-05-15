using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript.Messages
//{
/// <summary>
/// 返回登陆是否成功
/// </summary>
    class N_msg_canLoad : A_baseMsg
    {
        /// <summary>
        /// 成功：true
        /// </summary>
        public bool m_load;
        public N_msg_canLoad() { }
        public N_msg_canLoad(bool _load) {
            m_msgName = this.GetType().ToString();
            m_load = _load;
        
        }

    }
//}
