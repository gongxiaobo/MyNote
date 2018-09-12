using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的步骤详细介绍
     /// 主要用于考试时显示步骤详情
     /// </summary>
     [Serializable]
     public class N_connectDetail
     {
          /// <summary>
          /// 步骤ID
          /// </summary>
          public string m_ID;
          /// <summary>
          /// 中文介绍
          /// </summary>
          public string m_detail_ch;
          /// <summary>
          /// 外文介绍
          /// </summary>
          public string m_detail_eg;

     } 
}
