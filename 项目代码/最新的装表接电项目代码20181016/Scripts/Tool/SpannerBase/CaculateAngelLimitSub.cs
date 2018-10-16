using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 旋钮在换位内分为几个档位
     /// 当旋钮停止操作，自定回到最近的档位上
     /// </summary>
     public class CaculateAngelLimitSub : CaculateAngelLimit
     {
          AB_subsection m_subsection = null;
          /// <summary>
          /// 值的分段
          /// </summary>
          public int m_subvalue = 2;
          protected override void Start()
          {
               base.Start();
               m_subsection = new N_subsection();
               m_subsection.fn_init(m_limitRang.x, m_limitRang.y, m_subvalue, fnp_nearValue);
          }
          protected virtual void fnp_nearValue(float _value)
          {

               //Debug.Log("<color=red>XXXXXXred:</color>"+_value);

               fnp_onoffSound("btn_down");
               fn_setTo(_value);
               //if (_value == m_limitRang.x || _value == m_limitRang.y)
               //{
               //     return;
               //}
               //else
               //{
               //     fn_setTo(_value);
               //}

          }

          //protected override void fnp_handleRotate()
          //{
          //     base.fnp_handleRotate();
          //     m_subsection.fn_inputValue(AllRotate);
          //}
          public override void fn_endControl()
          {
               base.fn_endControl();
               //if (AllRotate == m_limitRang.y)
               //{
               //     fnp_onoffSound("btn_down");
               //}
               //else if (AllRotate == m_limitRang.x)
               //{
               //     fnp_onoffSound("btn_down");
               //}
               //else
               //{

               m_subsection.fn_inputValue(AllRotate);
               //}
          }

     }

}