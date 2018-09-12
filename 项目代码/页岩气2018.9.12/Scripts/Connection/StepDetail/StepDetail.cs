using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的步骤操作文字表述
     /// </summary>
     public class StepDetail : MonoBehaviour
     {
          /// <summary>
          /// 语言转换
          /// </summary>
          public N_UIdata m_name;
          public Text m_detail;
          public Text m_title;
          // Use this for initialization
          void Start()
          {
               GlobalEventSystem<Event_StepDetail>.eventHappened += fnp_SetStepDetail;
               //m_detail = GetComponentInChildren<Text>();
          }
          protected void fnp_SetStepDetail(Event_StepDetail _detail)
          {
               if (m_detail!=null)
               {
                    m_detail.text = _detail.m_detail;
               }
          }
         
     } 
}
