using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 虚拟零件关联实体零件的操作，初始化
     /// </summary>
     public class N_VirtualAttach : AB_VirtualAttach
     {
          I_Control mi_changeValue = null;
          protected override void Start()
          {
               base.Start();
               S_VirtualAttach.Instance.fn_login(m_AttachPartID, this);
          }

          protected override void fn_findPart()
          {
               AB_PullOut t_pullout = S_PullOutPart.Instance.fn_getPullOut(m_AttachPartID);
               if (t_pullout==null)
               {
                    
                    Debug.Log("<color=red>not find part!</color>");
                    return;
               }
               GameObject t_part = t_pullout.M_PullObj;
               if (t_part==null)
               {
                    Debug.Log("<color=red>not find M_PullObj!</color>");
                    return;
               }
               //m_AttachPartObj = t_part;
               //加入零件的状态事件改变
               AB_ThePart t_partEvent = t_part.GetComponent<AB_ThePart>();
               if (t_partEvent==null)
               {
                    return;
               }
               t_partEvent.M_PartStateChangeEvent += fnp_StateChangeEvent;
               fnp_StateChangeEvent(t_partEvent.M_PartState);
               //mi_changeValue.fni_level(t_partEvent.M_PartState.GetHashCode());

          }
          //GameObject m_AttachPartObj = null;
          bool m_init = false;
          public override void fn_init()
          {
               if (m_init)
               {
                    return;
               }
               m_init = true;

               fn_findPart();
          }
          /// <summary>
          /// 当零件状态改变，这里虚拟零件的状态也同步更新
          /// </summary>
          /// <param name="_partState"></param>
          protected virtual void fnp_StateChangeEvent(E_ThePartState _partState)
          {
               if (mi_changeValue==null)
               {
                    mi_changeValue = GetComponent<I_Control>();
               }
               if (mi_changeValue!=null)
               {
                    mi_changeValue.fni_level(_partState.GetHashCode()); 
               }
          }

     } 
}
