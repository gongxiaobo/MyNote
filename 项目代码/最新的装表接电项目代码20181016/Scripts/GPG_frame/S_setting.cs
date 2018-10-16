using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 全局的设置
     /// </summary>
     public static class S_setting
     {
          /// <summary>
          /// 配置文件的路径
          /// </summary>
          public readonly static string m_pathConfig = Application.streamingAssetsPath + "/" + "config" + "/";
          /// <summary>
          /// 声音文件的读取位置
          /// </summary>
          public readonly static string m_pathSound = Application.streamingAssetsPath + "/" + "sound" + "/";
          /// <summary>
          /// 单位是公制还英制
          /// metric 是工制
          /// inch 是英制
          /// </summary>
          public static string m_unit = "metric";

     }

}