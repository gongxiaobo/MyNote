using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 一个可以交互的物体的可控接口
     /// </summary>
     public interface I_Control
     {
          /// <summary>
          /// 开启
          /// </summary>
          void fni_on(E_ControlType _controlType = E_ControlType.e_normal);
          /// <summary>
          /// 关闭
          /// </summary>
          void fni_off(E_ControlType _controlType = E_ControlType.e_normal);
          /// <summary>
          /// 设置int 数值
          /// </summary>
          /// <param name="_level"></param>
          void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal);
          /// <summary>
          /// 设置float 数值
          /// </summary>
          /// <param name="_level"></param>
          void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal);
          /// <summary>
          /// 设置string 值
          /// </summary>
          /// <param name="_txt"></param>
          void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal);
          /// <summary>
          /// 状态值被改变后的操作
          /// </summary>
          /// <param name="_statename">状态值的名称</param>
          /// <param name="_value">状态值</param>
          /// <param name="_controlType">操作类型</param>
          void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal);
     }
     /// <summary>
     /// 操作接口的操作类型参数
     /// </summary>
     public enum E_ControlType
     {
          /// <summary>
          /// 普通操作
          /// </summary>
          e_normal = 1,
          /// <summary>
          /// 初始化操作
          /// </summary>
          e_init = 2,
     }

}