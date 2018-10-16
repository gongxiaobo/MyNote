using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 划片的控制接口实现
     /// </summary>
     public class N_SliceControl : MonoBehaviour, I_Control, I_OnOffTrigger
     {
          public string m_state = "off";
          Animator m_ani = null;
          void Start()
          {
               if (m_ani == null)
               {
                    m_ani = GetComponent<Animator>();
               }
               if (m_ani==null)
               {
                    m_ani = GetComponentInChildren<Animator>();
               }
          }
          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //if (_controlType== E_ControlType.e_normal)
               //{
                    //if (m_state == "off")
                    //{
               if ( m_state == "off")
               {
                    m_state = "on";
                    fnp_play(); 
               }
                         fnp_setState(m_state);
                    //} 
               //}
               //if (_controlType== E_ControlType.e_init)
               //{
               //     m_state = "on";
               //     fnp_play();
               //}
               
          }

          private void fnp_setState(string _state)
          {
               AB_SetState t_setState = new N_SetState();
               t_setState.fn_setState("onoff", _state, GetComponent<AB_HandleEvent>());
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //if (_controlType== E_ControlType.e_normal)
               //{
                    //if (m_state == "on")
                    //{
               if (m_state == "on")
               {
                    m_state = "off";
                    fnp_play(); 
               }
                         fnp_setState(m_state);
                    //} 
               //}
               //if (_controlType == E_ControlType.e_init)
               //{
               //     m_state = "off";
               //     fnp_play();
               //}
          }

          #region hide
          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          } 
          #endregion
          protected void fnp_play()
          {
               if (m_ani != null)
               {
                    m_ani.SetTrigger(m_state);
               }
          }

          public void fni_OnOffTrigger()
          {
               if (m_state == "off")
               {
                    fni_on();
               }
               else
               {
                    fni_off();
               }
          }
     }

}