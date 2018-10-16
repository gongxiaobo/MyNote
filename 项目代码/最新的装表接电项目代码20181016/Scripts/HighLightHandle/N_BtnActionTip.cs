using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 实现动作的提示图标
     /// </summary>
     public class N_BtnActionTip : AB_BtnActionTip
     {

          public override void fn_light()
          {
               if (S_HandButton.Instance.ActionTip != null)
               {
                    S_HandButton.Instance.ActionTip.fn_show(m_ActionTipName);
               }
          }

          public override void fn_endLight()
          {
               if (S_HandButton.Instance.ActionTip != null)
               {
                    S_HandButton.Instance.ActionTip.fn_hide(m_ActionTipName);
               }
          }
     }

}