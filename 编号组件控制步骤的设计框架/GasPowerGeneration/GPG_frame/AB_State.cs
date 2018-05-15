using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 获取状态值
     /// </summary>
     public abstract class AB_State : MonoBehaviour
     {
          /// <summary>
          /// item 类型，用于判断是交互类型还是观察类型
          /// 主要是步骤检查中使用
          /// </summary>
          public E_ItemType m_ItemType = E_ItemType.e_interactive;
          /// <summary>
          /// 值类型
          /// </summary>
          public E_valueType m_ItemValueType = E_valueType.e_inter_onoff;
          //public T fn_getValue()
          /// <summary>
          /// 获取一个物体上的状态值数组
          /// </summary>
          /// <returns></returns>
          public abstract StateValue[] fn_getValue();
          /// <summary>
          /// 根据名称，找到状态值
          /// </summary>
          /// <param name="_name"></param>
          /// <returns></returns>
          public abstract StateValue fn_getValue(string _name);
          /// <summary>
          /// 获取状态有效字段
          /// </summary>
          /// <returns></returns>
          public abstract string fn_getMainValue();
          /// <summary>
          /// 根据值的类型名称获取值
          /// </summary>
          /// <param name="_statevaluetype"></param>
          /// <returns></returns>
          public abstract string fn_getMainValue(E_StateValueType _statevaluetype);
          /// <summary>
          /// 获取状态值
          /// </summary>
          /// <param name="_name"></param>
          /// <returns></returns>
          public abstract string fn_getOtherValue(string _name);
          /// <summary>
          /// 初始化的数值设置
          /// </summary>
          /// <param name="_initDate"></param>
          public abstract void fn_setValue(StateValue[] _initDate);
          /// <summary>
          /// 改变一项的参数
          /// </summary>
          /// <param name="_changeValue"></param>
          public abstract void fn_setValue(StateValue _changeValue);
          /// <summary>
          /// 直接设置一个状态值
          /// </summary>
          /// <param name="_name"></param>
          /// <param name="_changeValue"></param>
          public abstract void fn_setValue(string _name, string _changeValue);

          public abstract void fn_debugContent();


     }

}