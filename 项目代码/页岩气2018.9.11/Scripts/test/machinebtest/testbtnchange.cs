using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     /// <summary>
     /// 表现效果类
     /// </summary>
     public class testbtnchange : MonoBehaviour, I_Control
     {


          private Vector3 clickdepth = new Vector3(-0.05f, 0, 0);
          private AB_HandleEvent m_handle;
          Vector3 pos;
          void Awake()
          {
               pos = transform.position;
               m_handle = GetComponent<AB_HandleEvent>();
          }


          private void ClickState(bool click)
          {

               transform.position = click ? pos + clickdepth : pos;

               //if(click)
               //    mana
          }

          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               ClickState(true);
               StateValueBool b_value = (StateValueBool)m_handle.fn_get("onoff");
               AB_Message message = new N_Message();
               message.fn_init(E_MessageType.e_outside, new StateValueBool[1] { new StateValueBool("onoff", !b_value.m_date) }, "", m_handle.ID.m_ID);
               m_handle.fn_HandleMsg(message);
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               ClickState(false);
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
               throw new System.NotImplementedException();
          }
     }

}