using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 科目的步骤
     /// </summary>
     public class subject_step
     {
          /// <summary>
          /// 编号
          /// </summary>
          public string m_index;
          /// <summary>
          /// 步骤编号
          /// </summary>
          public int m_step;
          /// <summary>
          /// item序号
          /// </summary>
          public int m_id;
          /// <summary>
          /// 正确的状态
          /// </summary>
          public string m_state;
          /// <summary>
          /// 检查条件
          /// </summary>
          public string m_condition;
          /// <summary>
          /// 中文介绍
          /// </summary>
          public string m_ch_txt;
          /// <summary>
          /// 中文声音名称
          /// </summary>
          public string m_ch_voice;
          /// <summary>
          /// 英文介绍
          /// </summary>
          public string m_en_txt;
          /// <summary>
          /// 英文声音名称
          /// </summary>
          public string m_en_voice;
     }

}