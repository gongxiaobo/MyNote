using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.NormalControl
{
     /// <summary>
     /// 普通操作类型的操作接口,onoff类型
     /// </summary>
     class NormalControl_01 : MonoBehaviour, I_Control
     {

          AB_SetState m_set = new N_SetState();
          AB_HandleEvent m_handleevent = null;
          protected void fnp_find()
          {
               if (m_handleevent == null)
               {
                    m_handleevent = GetComponent<AB_HandleEvent>();
               }
          }
          public virtual void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
               fnp_find();
               if (_controlType == E_ControlType.e_normal)
               {
                    m_set.fn_setState("onoff", "on", m_handleevent);
               }
          }

          public virtual void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_find();
               if (_controlType == E_ControlType.e_normal)
               {
                    m_set.fn_setState("onoff", "off", m_handleevent);
               }
               //throw new System.NotImplementedException();
          }

          public virtual void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_find();
               //throw new System.NotImplementedException();
          }

          public virtual void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_find();
               //throw new System.NotImplementedException();
          }

          public virtual void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_find();
               //throw new System.NotImplementedException();
          }

          public virtual void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_find();
               //throw new System.NotImplementedException();
          }
     }
}
