using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 通过ID去找到结果的触发
     /// 在零件的位置发送变化的时候
     /// </summary>
     public class N_PartInOutLogic_01 : AB_PartInOutLogic
     {
          int m_ID = 0;
          protected override void Start()
          {
               base.Start();
               AB_NameFlag t_nf=GetComponent<AB_NameFlag>();
               if (t_nf!=null)
               {
                    m_ID = t_nf.M_nameID;
               }
               else
               {
                    Debug.Log("<color=red>not find AB_NameFlag!</color>");
               }

               AB_ThePart t_thepart = GetComponent<AB_ThePart>();
               if (t_thepart!=null)
               {
                    t_thepart.M_PartStateChangeEvent += fnp_PartPosChange;
               }
               else
               {
                    Debug.Log("<color=red>not find AB_ThePart!</color>");
               }

          }
          bool m_inMac = false;
          bool m_outMac = false;
          /// <summary>
          ///触发的反射条件
          /// </summary>
          AB_HandleEvent m_HandleEvent = null;
          public override void fnp_PartPosChange(E_ThePartState _partState)
          {

               Debug.Log("<color=blue>触发的反射条件</color>" + _partState);
     
               if (_partState== E_ThePartState.e_inMachine)
               {
                    if (m_inMac == false)
                    {
                         m_inMac = true;
                         m_outMac = false;
                         fnp_Result("inMac");
                         Debug.Log("<color=blue>零件的反射条件 零件在机器上</color>");
                    }
                   
     
               }
               else
               {
                    if (m_outMac == false)
                    {
                         m_outMac = true;
                         m_inMac = false;
                         fnp_Result("outMac");
                         Debug.Log("<color=blue>零件的反射条件 零件没有在机器上</color>");
                    }
                   
               }
          }
          /// <summary>
          /// 发送在机器或者不再机器的位置消息反射情况
          /// </summary>
          /// <param name="_rname"></param>
          protected virtual void fnp_Result(string _rname)
          {
               AB_PullOut t_po = S_PullOutPart.Instance.fn_getPullOut(m_ID);
               if (t_po==null)
               {
                    Debug.Log("<color=red>not find AB_PullOut!</color>");
                    return;
               }
               if (m_HandleEvent == null)
               {
                    m_HandleEvent = t_po.gameObject.GetComponent<AB_HandleEvent>(); 
               }
               if (m_HandleEvent == null)
               {
                    Debug.Log("<color=red>not find AB_HandleEvent!</color>");
                    return;
               }
               AB_ResultAction t_ra = t_po.gameObject.GetComponent<AB_ResultAction>();
               if (t_ra!=null)
               {
                    t_ra.fn_SendResultMsg(_rname, m_HandleEvent);
               }
               else { Debug.Log("<color=red>not find AB_ResultAction!</color>"); }
              
     

          }
     } 
}
