using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 使用工具的额外信息
     /// </summary>
     public class N_ToolTriggerInfo_01 : AB_ToolTriggerInfo
     {
          [Tooltip("零件拿出使用工具，还是放入时使用工具")]
          public E_ToolTriggerType m_triggertype = E_ToolTriggerType.e_useToolFirst;
          public Transform m_controlObj = null;
          public override Transform fn_GetControlObj()
          {
               return m_controlObj;
          }
          [SerializeField]
          BoxCollider t_bc;
          /// <summary>
          /// 触发器的显示隐藏
          /// </summary>
          /// <param name="_show"></param>
          public override void fn_HideToolTrigger(bool _show = false)
          {
               AB_NameFlag t_nf = GetComponent<AB_NameFlag>();
               Debug.Log(t_nf .M_nameID+ "<color=blue>:触发器的显示隐藏</color>" + _show);
     
               if (t_bc != null)
               {
                    t_bc.enabled = _show;
               }
          }
          protected virtual void Start()
          {
               AB_NameFlag t_nf = GetComponent<AB_NameFlag>();

               if (t_nf!=null)
               {
                    if (t_nf.M_nameID==0)
                    {

                         Debug.Log("<color=blue>AB_NameFlag id==0 </color>");
     
                         return;
                    }
                    if (m_triggertype== E_ToolTriggerType.e_useToolFirst)
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
          public GameObject m_toolObj = null;
          public override GameObject M_ToolObj
          {
               get
               {
                    return m_toolObj;
               }
               set
               {
                    m_toolObj=value;
                    if (value != null && m_controlObj!=null)
                    {
                         I_ToolObjToPart t_toolobj = m_controlObj.gameObject.GetComponent<I_ToolObjToPart>();
                         if (t_toolobj!=null)
                         {
                              t_toolobj.fni_ToolObjToPart(value);
                         }
                         else
                         {
                              Debug.Log("<color=red>not find I_ToolObjToPart in part parent!</color>");
                         }

                    }
               }
          }
     }
}
