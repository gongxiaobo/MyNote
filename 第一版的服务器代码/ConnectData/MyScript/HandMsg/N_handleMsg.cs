using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript
//{
    /// <summary>
    /// 用于解析客服端发过来的消息
    /// </summary>
    class N_handleMsg : A_handleMsg
    {
        /// <summary>
        /// 反馈接口
        /// </summary>
        protected I_sendBackClient mi_sendBackClient;
        public override void fn_init(I_sendBackClient _sendClient)
        {
            m_stop = false;
            if (_sendClient != null)
            {
                mi_sendBackClient = _sendClient;
            }
            else
            {
                mi_sendBackClient = null;
                m_stop = true;
            }
        }
        public override void fn_parse(string _jsonmsg)
        {
         

        }
        public override void fn_stop()
        {
            m_stop = true;
        }
    }
//}
