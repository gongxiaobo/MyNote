using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.LearnModeConnect
{
     /// <summary>
     /// 918：在教学模式下的连线处理
     /// 当开始连线前播放语音提示，在语音提示完成后，执行链接操作。完成这一步的学习
     /// </summary>
     public abstract class AB_LearnModeConnect : MonoBehaviour
     {
          /// <summary>
          ///  一次链接请求，需要传入配置表中的链接信息
          /// </summary>
          /// <param name="_portID">当前连接的接口编号</param>
          /// <param name="_portState">当前接口的已经链接的状态</param>
          /// <param name="_tableData">配置表中的链接信息</param>
          /// <param name="_soundName">当前步骤的提示语音</param>
          public abstract void fn_callOneConnect(string _portID, string _portState, string _tableData, string _soundName);
          /// <summary>
          /// 是否暂停
          /// </summary>
          public abstract bool M_isPause { get; set; }
     }
}
