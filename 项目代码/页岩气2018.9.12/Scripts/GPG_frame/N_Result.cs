using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{

     [Serializable]
     public class N_Result
     {
          /// <summary>
          /// 去影响按个按钮
          /// </summary>
          public int m_ToId;
          /// <summary>
          /// 消息的类型
          /// </summary>
          public E_MessageType m_msgType;
          /// <summary>
          /// 影响按钮的状态值
          /// </summary>
          public string m_SetState;

     } 
}
