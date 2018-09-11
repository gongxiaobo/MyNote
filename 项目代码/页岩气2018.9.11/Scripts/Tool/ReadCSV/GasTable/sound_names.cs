using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 声音表格
     /// </summary>
     public class sound_names
     {
          public string m_id;
          /// <summary>
          /// 声音名称
          /// </summary>
          public string m_name;

     }
     /// <summary>
     /// 声音的分类
     /// 背景声音 bg
     /// 音效 effect
     /// 人声 humansound
     /// </summary>
     public class sound_names_type : sound_names
     {
          /// <summary>
          /// 声音的类型，根据类型来挂载混音
          /// </summary>
          public string m_type;
     }

}