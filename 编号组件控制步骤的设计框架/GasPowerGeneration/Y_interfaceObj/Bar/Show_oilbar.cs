using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{
     public class Show_oilbar : MonoBehaviour, I_Control, I_Showbar
     {
          bool show = false;
          private Transform Bar;
          private Transform low;
          private Transform full;
          private Transform middle;
          private N_HandleEvent_init handler;
          // Use this for initialization
          void Start()
          {
               Bar = TransformHelper.FindChild(transform, "Bar");
               low = TransformHelper.FindChild(transform, "Low");
               full = TransformHelper.FindChild(transform, "Full");
               middle = TransformHelper.FindChild(transform, "Middle");
               handler = GetComponent<N_HandleEvent_init>();
               HideBar();
          }


          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {


          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    switch (_level.ToString())
                    {
                         case "1":
                              low.gameObject.SetActive(true);
                              full.gameObject.SetActive(false);
                              middle.gameObject.SetActive(false);

                              break;
                         case "2":
                              low.gameObject.SetActive(false);
                              full.gameObject.SetActive(false);
                              middle.gameObject.SetActive(true);
                              break;
                         case "3":
                              low.gameObject.SetActive(false);
                              full.gameObject.SetActive(true);
                              middle.gameObject.SetActive(false);
                              break;
                    }
                    StateValueString state = (StateValueString)handler.fn_get("floatvalue");
                    state.m_date = _level.ToString();
                    handler.fn_set(state);
               }

          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void ShowBar()
          {
               if (show)
               {
                    HideBar();

               }
               else
               {
                    Bar.DOScale(1, 0.3f);

               }
               show = !show;
          }


          public void HideBar()
          {
               Bar.DOScale(0, 0);
          }
     }

}