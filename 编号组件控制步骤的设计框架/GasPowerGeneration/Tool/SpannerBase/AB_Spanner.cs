using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 旋钮类型的控制抽象
     /// </summary>
     public abstract class AB_Spanner : MonoBehaviour, I_Control, I_SpannerRotateValue
     {
          /// <summary>
          /// 手柄控制
          /// </summary>
          /// <param name="_hand"></param>
          public abstract void fn_startControl(Transform _hand);
          /// <summary>
          /// 结束手柄控制
          /// </summary>
          public abstract void fn_endControl();
          /// <summary>
          /// 设置到指定角度
          /// </summary>
          /// <param name="_angel"></param>
          public abstract void fn_setTo(float _angel);
          /// <summary>
          /// 设置到指定的状态
          /// </summary>
          /// <param name="_com"></param>
          public abstract void fn_setTo(string _com);



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



          public virtual bool fni_valueToEdge()
          {
               return true;
          }
          public virtual float fni_getRotateValue()
          {
               return 0f;
          }
          public virtual Vector2 fni_getLimit() { return Vector2.one; }
          public virtual bool fni_valueToBig() { return false; }
          public virtual bool fni_valueToSmall() { return false; }
     }

}