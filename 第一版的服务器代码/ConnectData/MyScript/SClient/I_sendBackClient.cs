using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript
//{

    /// <summary>
    /// 反馈客服端接口
    /// </summary>
    interface I_sendBackClient
    {
        /// <summary>
        /// 反馈接口
        /// </summary>
        /// <param name="_jsonMsg"></param>
        void fn_sendback(string _jsonMsg);
    }
//}
