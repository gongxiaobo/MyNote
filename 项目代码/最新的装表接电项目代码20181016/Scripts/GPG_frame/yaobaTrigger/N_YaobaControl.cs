using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把的控制
     /// </summary>
     public class N_YaobaControl : MonoBehaviour, I_Control
     {

          protected AB_HandleEvent m_handleEvent = null;
          // Use this for initialization
          protected virtual void Start()
          {

               m_handleEvent = GetComponent<AB_HandleEvent>();
          }
          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public virtual void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
               StateValue t_sv = m_handleEvent.fn_get("level");
               if (t_sv != null)
               {
                    StateValueString t_s = t_sv as StateValueString;
                    t_s.m_date = _level.ToString();
                    m_handleEvent.fn_set(t_s);
                    //fnp_Result("on");
               }
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
     } 
}
