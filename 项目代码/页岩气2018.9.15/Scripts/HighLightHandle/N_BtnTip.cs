using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 实现高亮手柄上的一个按钮
     /// </summary>
     public class N_BtnTip : AB_BtnTip
     {


          public override void fn_light()
          {
               if (S_HandButton.Instance.RightHandLightBtn != null)
               {
                    S_HandButton.Instance.RightHandLightBtn.fn_setHighLight(fnp_getName());
               }
          }

          public override void fn_endLight()
          {
               if (S_HandButton.Instance.RightHandLightBtn != null)
               {
                    S_HandButton.Instance.RightHandLightBtn.fn_setDefault();
               }
          }
          protected virtual string fnp_getName()
          {
               switch (m_btnName)
               {
                    case E_HandBtnName.e_null:
                         break;
                    case E_HandBtnName.e_trigger:
                         return "trigger";
                    case E_HandBtnName.e_pad:
                         return "trackpad";
                    default:
                         break;
               }
               return "";
          }
     } 
}
