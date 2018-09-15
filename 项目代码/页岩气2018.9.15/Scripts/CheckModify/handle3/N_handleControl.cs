using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 旋碟阀，旋塞阀的控制
     /// </summary>
     public class N_handleControl : MonoBehaviour, I_Control
     {
          AB_Spanner m_spanner = null;
          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_find();
               if (m_spanner==null)
               {
                    return;
               }
               //throw new System.NotImplementedException();
               if (_controlType== E_ControlType.e_init)
               {
                    //m_spanner.fn_setTo(0f);
               }
               else
               {

               }
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_find();
               //throw new System.NotImplementedException();
               if (_controlType == E_ControlType.e_init)
               {
                    m_spanner.fn_setTo(1f);
               }
               else
               {

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
               throw new System.NotImplementedException();
          }
          protected virtual void fnp_find()
          {
               if (m_spanner==null)
               {
                    m_spanner = GetComponentInChildren<AB_Spanner>();
               }
          }
     } 
}
