using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 锁定状态的开关类型，锁定就是把碰撞体关闭，不能被操作，
     /// 如果需要操作，需要解除锁定
     /// </summary>
     public class N_Button_lock : N_ButtonOnOffWithState
     {
          [Tooltip("false==隐藏")]
          public bool m_HideBoxStart = false;
          protected BoxCollider m_box = null;
          protected override void Start()
          {
               base.Start();
               m_box = GetComponentInChildren<BoxCollider>();
               fnp_lock(m_HideBoxStart);
          }

          private void fnp_lock(bool _lockstate)
          {

               if (m_box != null)
               {
                    m_box.enabled = _lockstate;
               }
          }

          public override void fn_startControl(Transform _hand)
          {
               base.fn_startControl(_hand);
          }
          public override void fn_endControl()
          {
               base.fn_endControl();

          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);

               Debug.Log("<color=red>red:</color>" + _statename + "|" + _value);

               if (_statename == "lock")
               {//
                    if (_value == "lock")
                    {
                         if (m_isStartHanding)
                         {
                              fn_endControl();
                         }
                         fnp_lock(false);
                         Debug.Log("<color=red>锁定</color>");

                    }
                    else if (_value == "unlock")
                    {
                         //还要检查护罩是否取下
                         bool t_pass = (m_condition != null) ? m_condition.fn_check("unlock") : true;
                         if (t_pass)
                         {
                              fnp_lock(true);

                              Debug.Log("<color=red>解除锁定</color>");

                         }

                    }

               }
          }


     }

}