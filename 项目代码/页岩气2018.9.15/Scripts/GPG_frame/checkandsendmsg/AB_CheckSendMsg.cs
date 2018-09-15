using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 检查是否达到目标
     /// </summary>
     public abstract class AB_CheckSendMsg : MonoBehaviour
     {
          /// <summary>
          /// 开始检查
          /// </summary>
          public abstract void fn_StartCheck();
          /// <summary>
          /// 结束检查
          /// </summary>
          public abstract void fn_endCheck();
          /// <summary>
          /// 条件判断
          /// </summary>
          /// <returns></returns>
          protected abstract bool fnp_Check();
          /// <summary>
          /// 发送消息到管理中心
          /// </summary>
          protected abstract void fnp_SendMsg();
     } 
}
