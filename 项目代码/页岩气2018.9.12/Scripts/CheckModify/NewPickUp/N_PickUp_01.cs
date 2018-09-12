using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 这种拿起物体和普通拿起物体不同
     /// 在拿这个物体前这个物体时父子链接到其他物体上的，需要先脱离当前物体，然后在链接到手上
     /// </summary>
     public class N_PickUp_01 : N_PickUp, I_PickUpFromTool
     {
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               //base.fn_trigger(_button, _hand);
               //设置零件的状态
               AB_ThePart t_thepart = this.gameObject.GetComponent<AB_ThePart>();
               if (t_thepart != null)
               {
                    if (t_thepart.M_PartState== E_ThePartState.e_onTool)
                    {//在机器上的工具上的时候
                         Rigidbody t_toolRigi = this.gameObject.transform.parent.GetComponent<Rigidbody>();
                         bool t_refresh = false;
                         if ( t_toolRigi!=null)
                         {//为了处理工具链接比较大的物体后，出现任意旋转的情况
                              if (t_toolRigi.isKinematic == false && t_toolRigi.useGravity)
                              {
                                   t_toolRigi.isKinematic = true;
                                   t_refresh = true;
                              }
                              
                         }
                         //先脱离原来物体
                         if (this.gameObject.transform.parent != null)
                         {
                              this.gameObject.transform.parent = null;
                         }
                         //手柄的链接
                         if (mi_hand == null)
                         {
                              mi_hand = _hand;
                         }
                         fnp_PickCheck(_button, _hand);
                         //从工具上拿起零件后，反馈给工具的状态值的设置
                         if (m_callback != null)
                         {
                              m_callback();
                              m_callback = null;
                         }
                         //t_thepart.M_PartState = E_ThePartState.e_inHand;
                         if (t_toolRigi != null && t_refresh)
                         {

                              t_toolRigi.useGravity = false;
                              t_toolRigi.isKinematic = false;
                              t_toolRigi.useGravity = true;
                         }

                    }
                    else if (t_thepart.M_PartState== E_ThePartState.e_inHand||
                         t_thepart.M_PartState == E_ThePartState.e_onGround)
                    {
                         base.fn_trigger(_button, _hand);
                    }
                   
               }
               
               
          }
          protected override void fnp_pickUp(I_HandButton _hand)
          {
               base.fnp_pickUp(_hand);
               //设置零件的状态
               AB_ThePart t_thepart = this.gameObject.GetComponent<AB_ThePart>();
               if (t_thepart != null)
               {
                    t_thepart.M_PartState = E_ThePartState.e_inHand;
               }
          }
          protected override void fnp_putDown()
          {
               base.fnp_putDown();
               //设置零件的状态
               AB_ThePart t_thepart = this.gameObject.GetComponent<AB_ThePart>();
               if (t_thepart != null)
               {
                    t_thepart.M_PartState = E_ThePartState.e_onGround;
               }
          }
          #region I_PickUpFromTool
          Action m_callback = null;
          public void fni_PickUpPartFromTool(Action _callback)
          {
               m_callback = _callback;
          } 
          #endregion
     } 
}
