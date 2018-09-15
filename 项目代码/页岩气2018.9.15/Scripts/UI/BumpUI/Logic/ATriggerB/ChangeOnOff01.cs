using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 一个参数变化后一段时间后影响另外一个参数值
     /// 开关类型
     /// </summary>
     public class ChangeOnOff01 : ChangeOnOff
     {
          /// <summary>
          /// 在这个范围左右+-0.5f
          /// </summary>
          public float m_delay = 1f;
          public override void fn_ToDo()
          {
               
               //Debug.Log("<color=red>this gameobject </color>"+this.gameObject.name);
     
               //base.fn_ToDo();
               if (m_triggerID == m_TriggerFrom)
               {//泵的开启按钮
                    StopCoroutine("fnp_dolater");
                    StartCoroutine("fnp_dolater");

               }
          }
          IEnumerator fnp_dolater()
          {
               yield return new WaitForSeconds(m_delay+Random.Range(-0.5f,0.5f));
               if (mi_getOtherState.fni_otherState(m_TriggerFrom) == "on")
               {
                    m_control.fni_on();

               }
               else
               {
                    m_control.fni_off();
               }
          }

     } 
}
