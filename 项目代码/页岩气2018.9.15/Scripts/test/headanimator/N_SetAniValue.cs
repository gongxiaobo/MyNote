using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理focus的头部动画的控制
     /// </summary>
     public class N_SetAniValue : AB_SetAniValue
     {
          public string m_parameter1 = "leftright";
          public string m_parameter2 = "updown";
          /// <summary>
          /// 传入旋转值
          /// </summary>
          /// <param name="_value1">左右</param>
          /// <param name="_value2">上下</param>
          public override void fn_set(float _value1, float _value2)
          {
               fnp_getAni();

               //Debug.Log("<color=blue>blue:</color>" + rf1.fn_remap(_value1));
               float t1 = rf1.fn_remap(_value1);
               float t2 = rf2.fn_remap(_value2);
               m_ani.SetFloat(m_parameter1, t1);
               m_ani.SetFloat(m_parameter2, t2);

          }
          Animator m_ani = null;
          Remapfloat rf1 = null;
          Remapfloat rf2 = null;
          protected void fnp_getAni()
          {
               if (m_ani == null)
               {
                    m_ani = GetComponent<Animator>();
                    rf1 = new Remapfloat(2f, -2f, 30f, -30f);
                    rf2 = new Remapfloat(2f, -2f, 30f, -30f);

               }
               if (m_ani == null)
               {
                    Debug.Log("<color=red>can not find animator</color>");
                    m_ani = gameObject.AddComponent<Animator>();

               }
          }

     }

}