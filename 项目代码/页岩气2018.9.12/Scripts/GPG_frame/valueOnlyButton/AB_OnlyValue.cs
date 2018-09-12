using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 值类型的操作
     /// 只是对值的修改，没有表现
     /// </summary>
     public abstract class AB_OnlyValue : MonoBehaviour, I_Control
     {

          protected virtual void Start() { }
          public virtual void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public virtual void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public virtual void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public virtual void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public virtual void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }

          public virtual void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //throw new System.NotImplementedException();
          }
     } 
}
