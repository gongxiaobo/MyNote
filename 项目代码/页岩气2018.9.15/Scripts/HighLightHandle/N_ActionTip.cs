using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_ActionTip : AB_ActionTip
     {
          public bool m_hideStart = true;
          void Start()
          {
               S_HandButton.Instance.ActionTip = this;
               if (m_hideStart)
               {
                    fn_hide();
               }
          }
          public GameObject m_rotate, m_pad;
          protected E_ActionTip m_show;
          public override void fn_show(E_ActionTip _tip)
          {
               m_show = _tip;
               Invoke("fn_waitshow", 1f);
          }
          protected void fn_waitshow()
          {
               fnp_showWhich(m_show);
          }
          public override void fn_hide(E_ActionTip _tip)
          {
               CancelInvoke("fn_waitshow");

               fnp_showWhich(_tip, false);

          }

          public override void fn_hide()
          {
               fnp_showWhich(E_ActionTip.e_rotate, false);
               fnp_showWhich(E_ActionTip.e_pad, false);
          }
          protected virtual void fnp_showWhich(E_ActionTip _tip, bool _show = true)
          {
               switch (_tip)
               {
                    case E_ActionTip.e_null:
                         break;
                    case E_ActionTip.e_rotate:
                         {
                              if (m_rotate != null)
                              {
                                   m_rotate.SetActive(_show);
                              }
                         }
                         break;
                    case E_ActionTip.e_pad:
                         if (m_pad != null)
                         {
                              m_pad.SetActive(_show);
                         }
                         break;
                    default:
                         break;
               }
          }
     }

}