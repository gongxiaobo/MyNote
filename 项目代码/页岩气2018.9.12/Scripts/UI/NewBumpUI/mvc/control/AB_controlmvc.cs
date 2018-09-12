using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// mvc模式下的控制器归类
/// </summary>
public abstract class AB_controlmvc : MonoBehaviour, I_uiHandleMsg
{
     //public E_controlType m_controlType = E_controlType.e_normal;
	// Use this for initialization
	protected virtual void Start () {
          S_controlmvc.Instance.fn_putIn(this);
	}


     public virtual void fni_send(UIMsg _sendout)
     {
          //throw new System.NotImplementedException();
          S_controlmvc.Instance.fni_send(_sendout);
     }

     public virtual void fni_receive(UIMsg _get)
     {
          throw new System.NotImplementedException();
     }
}
