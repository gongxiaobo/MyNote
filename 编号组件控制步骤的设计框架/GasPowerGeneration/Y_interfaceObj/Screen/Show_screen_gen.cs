using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{
     public class Show_screen_gen : MonoBehaviour, I_Control
     {

          private RectTransform screen;
          private N_HandleEvent_init handler;
          private PanelChange panel;
          // Use this for initialization
          void Start()
          {
               screen = transform.GetChild(0).GetComponent<RectTransform>();
               handler = GetComponent<N_HandleEvent_init>();
               panel = transform.GetChild(0).GetComponent<PanelChange>();
          }


          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {

                    screen.DOScale(1, 0);
                    if (panel != null)
                         panel.Param_change();

               }

               else
               {
                    if (panel != null)
                         panel.Param_change();
               }
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    if (screen != null)
                    {
                         screen.DOScale(0, 0);
                    }
               }
               else
               {
                    if (screen != null)
                         screen.DOScale(0, 0);
                    StateValueString state;
                    if (handler != null)
                    {
                         state = (StateValueString)handler.fn_get("onoff");
                         state.m_date = "off";
                         handler.fn_set(state);
                    }
               }
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }


          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_statename == "electric")
               {
                    if (_value == "con")
                    {
                         if (screen != null)
                              screen.DOScale(1, 0);
                         StateValueString state;
                         if (handler != null)
                         {
                              state = (StateValueString)handler.fn_get("onoff");
                              state.m_date = "on";
                              handler.fn_set(state);
                         }
                         if (panel != null)
                              panel.Param_change();
                    }
                    else
                    {
                         fni_off();
                    }
               }
          }
     }

}