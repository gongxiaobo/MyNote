using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 通过itemid 去获取对应的item的状态值
     /// </summary>
     public class N_GetShowData : AB_GetShowData
     {


          public override void fn_showDate()
          {
               //throw new System.NotImplementedException();
               fn_getDate();
          }

          public override void fn_hideDtae()
          {
               //throw new System.NotImplementedException();
               m_mainValue = "";
          }
          /// <summary>
          /// 对应物体的主要状态值
          /// </summary>
          protected string m_mainValue = "";
          protected override void fn_getDate()
          {
               I_CheckValue ti_checkvalue = S_SceneMagT1.Instance;
               if (ti_checkvalue != null)
               {
                    m_mainValue = (m_ID > 0) ? ti_checkvalue.fni_checkDate(m_ID) : "";
                    //Debug.Log("<color=blue>blue:</color>" + m_mainValue);
               }

               if (m_mainValue != "")
               {
                    I_bubbleGetDetail ti_bubbledetail = S_SceneMagT1.Instance;
                    if (ti_bubbledetail != null)
                    {
                         AB_BubbleKeyValue t_kv = ti_bubbledetail.fni_bubbleGetDetail(m_ID);
                         if (t_kv != null)
                         {//为显示值加入单位或者替换成名称
                              m_mainValue = t_kv.fn_getValue(m_mainValue);
                         }
                    }
               }



          }
          public int m_ID = 0;
          public override int M_itemID
          {
               get
               {
                    return m_ID;
               }
               set
               {
                    m_ID = value;
               }
          }
     }

}