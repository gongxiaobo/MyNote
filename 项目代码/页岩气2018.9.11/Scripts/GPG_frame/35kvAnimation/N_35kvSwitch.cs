using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 35kv的分合闸的开关控制，状态只有分，合闸，每次操作完成后回到中间位置
     /// </summary>
     public class N_35kvSwitch : CaculateAngelLSOnlyLogic
     {
          protected override void fnp_nearValue(float _value)
          {
               base.fnp_nearValue(_value);
               //
               if (_value == -45)
               {//分
                    fnp_changeState("0");
               }
               else if (_value == 0)
               {//在关闭位置0
                    //fnp_changeState("1");
               }
               else if (_value == 45)
               {//合
                    fnp_changeState("2");
               }
          }
          //用于初始化设置，改变state的level值
          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_level.ToString() == "1")
               {//自动回到中间位置
                    return;
               }
               base.fni_level(_level, _controlType);

               //改变自身状态值
               AB_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("level", _level.ToString(), m_handleEvent);
          }
          private void fnp_changeState(string _value)
          {
               //改变自身状态值
               AB_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("level", _value, m_handleEvent);
               //触发反射
               AB_SendResult t_sendresult = new N_SendResult();
               t_sendresult.fn_SendResult(_value, m_resultAction, m_handleEvent);
               if (m_TriggerEffect)
               {
                    //触发效果
                    AB_TriggerEffect t_effect = new N_TriggerEffect();
                    t_effect.fn_effect(E_effectType.e_on, E_effectName.e_sound, m_handleEvent.gameObject.GetComponent<AB_Name>());
               }

          }
          /// <summary>
          /// 是否触发效果
          /// </summary>
          public bool m_TriggerEffect = true;
          public override void fn_endControl()
          {
               base.fn_endControl();
               //回到中间位置
               fn_setTo(0f);
          }

     } 
}
