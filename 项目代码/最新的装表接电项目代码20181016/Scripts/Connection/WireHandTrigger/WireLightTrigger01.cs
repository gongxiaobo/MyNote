using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 射线选择可触发的接口或者电线
     /// 加入接口，方便设置m_padPress的值在其他类中的设置
     /// </summary>
     public class WireLightTrigger01 : WireLightTrigger, I_SetWireBool
     {
          E_lightObjColor m_color;
          bool m_padPress = false;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (m_lightOneObj == null)
               {
                    m_lightOneObj = GetComponent<AB_LightOneObj>();
               }
               if (mi_lightchange == null)
               {
                    mi_lightchange = GetComponent<I_lightChangeMat>();
               }
               if (_button == E_buttonIndex.e_padTouched)
               {
                    if (mi_lightchange != null)
                    {
                         m_color = mi_lightchange.fni_getColorNow();
                         mi_lightchange.fni_changeColor(E_lightObjColor.e_red);
                         
                    }
                    if (m_lightOneObj != null)
                    {
                         m_lightOneObj.fn_light();
                    }
                    S_SoundComSingle.Instance.fnp_sound("rayhit");
               }
               if (_button == E_buttonIndex.e_padPressDown)
               {
                    if (S_selectUI.Instance.m_isDisLine)
                    {//如果是在拆线模式下，就不能进行接线操作
                         S_SoundComSingle.Instance.fnp_sound("Table_system_info 5");

                         return;
                    }
                    m_padPress = true;
                    S_ConnectWire.Instance.fn_select(
                         this.gameObject.GetComponent<AB_Name>());
                    S_SoundComSingle.Instance.fnp_sound("sure");
               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    if (m_padPress)
                    {
                         return;
                    }
                    if (mi_lightchange != null)
                    {
                         mi_lightchange.fni_changeColor(m_color);
                    }
                    if (m_lightOneObj != null)
                    {
                         m_lightOneObj.fn_endLigth();
                    }
               }
               
          }


          public void fni_setWireBool(bool _bl)
          {
               m_padPress=_bl;
          }
     } 
}
