using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0206/ :可以被触发的物体
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public abstract class A_TriggerObj : MonoBehaviour
     {
          /// <summary>
          /// 当前物体是否被选中的状态
          /// </summary>
          protected E_TriggerObjState m_state = E_TriggerObjState.e_unselected;
          public E_TriggerObjState M_state { get { return m_state; } }
          /// <summary>
          /// 按键的类型
          /// </summary>
          public E_buttonType m_buttonType = E_buttonType.e_null;
          // Use this for initialization
          protected virtual void Start()
          {
               return;
          }

          // Update is called once per frame
          //	void Update () {
          //	
          //	}

          public abstract void fn_trigger(E_buttonIndex _button, I_HandButton _hand);
          /// <summary>
          /// 手柄是否进入模型里面
          /// </summary>
          /// <param name="_inOut">If set to <c>true</c> in out.</param>
          public virtual void fn_handInOut(bool _inOut)
          {
               m_inOut = _inOut;

          }
          protected bool m_inOut = false;
          public bool M_inOut { get { return m_inOut; } }
          /// <summary>
          /// 是否可以触发,来区分双手的分开使用
          /// </summary>
          [HideInInspector]
          public bool m_canuse = true;
     }


     /////<summary>
     /////@ version 1.0 /2017.0215/ :按键类型分类，4类
     /////@ author gong
     /////@ version 1.1 /2017./ :
     /////@ author gong
     /////@ version 1.2 /2017./ :
     /////@ author gong
     /////@ version 1.3 /2017./ :
     /////@ author gong
     /////</summary>
     //public enum E_buttonType{
     //	e_null=0,
     //	/// <summary>
     //	/// UI按钮
     //	/// </summary>
     //	e_ui_button=1,
     //	/// <summary>
     //	/// 普通的开关按钮，自有开和关两种状态
     //	/// </summary>
     //	e_onoff_switch=2,
     //	/// <summary>
     //	/// 旋钮
     //	/// </summary>
     //	e_knob_button=3,
     //	/// <summary>
     //	/// 物体
     //	/// </summary>
     //	e_grip_obj=4,
     //
     //}

}