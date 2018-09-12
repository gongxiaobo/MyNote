using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_ToolTriggerInfo_02 : AB_ToolTriggerInfo
     {
          protected virtual void Start()
          {
               AB_NameFlag t_nf = GetComponent<AB_NameFlag>();

               if (t_nf != null)
               {
                    if (t_nf.M_nameID == 0)
                    {

                         Debug.Log("<color=blue>AB_NameFlag id==0 </color>");

                         return;
                    }
                    if (m_triggertype == E_ToolTriggerType.e_useToolFirst)
                    {
                         S_ToolTrigger.Instance.fn_logToolTrigger(t_nf.M_nameID, this);
                    }
                    else
                    {
                         S_ToolTrigger.Instance.fn_logToolPushTrigger(t_nf.M_nameID, this);
                    }
               }
               t_bc = GetComponent<BoxCollider>();
          }
          [Tooltip("零件拿出使用工具，还是放入时使用工具")]
          public E_ToolTriggerType m_triggertype = E_ToolTriggerType.e_useToolFirst;
          public override Transform fn_GetControlObj()
          {
               throw new System.NotImplementedException();
          }

          [SerializeField]
          BoxCollider t_bc;
          /// <summary>
          /// 触发器的显示隐藏
          /// </summary>
          /// <param name="_show"></param>
          public override void fn_HideToolTrigger(bool _show = false)
          {

               Debug.Log("<color=blue>触发器的显示隐藏</color>" + _show);

               if (t_bc != null)
               {
                    t_bc.enabled = _show;
               }
          }

          public override GameObject M_ToolObj
          {
               get
               {
                    throw new System.NotImplementedException();
               }
               set
               {
                    throw new System.NotImplementedException();
               }
          }
     } 
}
