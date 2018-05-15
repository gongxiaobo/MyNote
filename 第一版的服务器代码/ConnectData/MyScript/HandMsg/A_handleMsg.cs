using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript
//{
    /// <summary>
    ///2017.0323： 处理消息的抽象
    /// </summary>
    abstract class A_handleMsg
    {
        /// <summary>
        /// 解析消息
        /// </summary>
        /// <param name="收到的协议消息"></param>
        public abstract void fn_parse(string _jsonmsg);
        /// <summary>
        /// 停止解析资源
        /// 
        /// 
        /// </summary>
        protected bool m_stop;
        /// <summary>
        /// 初始化处理消息类
        /// </summary>
        /// <param name="反馈接口"></param>
        public abstract void fn_init(I_sendBackClient _sendClient);
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="_bl"></param>
        public abstract void fn_stop();

    }
//}
