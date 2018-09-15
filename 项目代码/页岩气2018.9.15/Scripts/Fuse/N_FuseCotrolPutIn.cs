using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_FuseCotrolPutIn : N_PickUp
     {
          protected override void fnp_PickCheck(E_buttonIndex _button, I_HandButton _hand)
          {
               if (GetComponent<AB_NameFlag>().M_nameID != 0)
               {//已经安装到熔断器卡槽中才检查条件
                    AB_CheckCondition t_check = new N_CheckCondition();
                    if (t_check.fn_check("lock", GetComponent<AB_Condition>()) == false)
                    {//条件检查
                         return;
                    }
               }
               base.fnp_PickCheck(_button, _hand);
          }
          protected override void fnp_pickUp(I_HandButton _hand)
          {

               FixedJoint t_fj = gameObject.GetComponent<FixedJoint>();
               if (t_fj != null)
               {
                    if (t_fj.connectedBody != null)
                    {
                         AB_haveFuse t_havefuse =
                              t_fj.connectedBody.gameObject.GetComponent<AB_haveFuse>();
                         t_havefuse.fn_connectFuse(false);
                         t_havefuse = null;
                         AB_FuseState t_otherFuseState =
                              t_fj.connectedBody.gameObject.GetComponent<AB_FuseState>();
                         t_otherFuseState.fn_setState(false);
                         t_otherFuseState = null;

                         GetComponent<N_FusePutIn>().m_useTrigger = false;
                         Invoke("fnp_canTriggerDown", 1.5f);
                    }
                    t_fj.connectedBody = null;

                    //Destroy(t_fj);
               }
               Rigidbody t_rg = GetComponent<Rigidbody>();
               if (t_rg != null)
               {
                    t_rg.isKinematic = false;
               }
               base.fnp_pickUp(_hand);
               //if (m_isPick)
               //{//在手上
               //     //m_canTriggerDown = true;
               //     GetComponent<testPutIn>().m_useTrigger = false;
               //     Invoke("fnp_canTriggerDown", 1.5f);
               //}
               AB_Name t_othernameid = GetComponent<AB_Name>();
               AB_NameFlag t_nameflag = GetComponent<AB_NameFlag>();
               if (t_nameflag != null)
               {
                    if (t_nameflag.M_nameID != 0)
                    {//表示正在熔断器卡槽中，被取出，发送消息给卡槽
                         AB_SendMsg t_sendmsg = new N_SendMsg();
                         t_sendmsg.fn_sendmsg(E_MessageType.e_inside, E_valueType.e_inter_onoff,
                              t_othernameid.m_ID, t_nameflag.M_nameID, "off", GetComponent<AB_HandleEvent>());

                         t_nameflag.M_nameID = 0;
                    }
               }
               AB_SetState t_set = new N_SetState();
               t_set.fn_setState("level", "1", GetComponent<AB_HandleEvent>());
          }
          protected override void fnp_putDown()
          {
               //base.fnp_putDown();
               FixedJoint t_fj = gameObject.GetComponent<FixedJoint>();
               if (t_fj != null)
               {
                    t_fj.connectedBody = null;
                    Destroy(t_fj);
               }
               Rigidbody t_rg = GetComponent<Rigidbody>();
               if (m_RemoveRigibody)
               {

                    if (t_rg != null)
                    {
                         Destroy(t_rg);
                    }
               }
               else
               {
                    if (t_rg != null)
                    {
                         t_rg.useGravity = true;
                         t_rg.isKinematic = false;
                    }

               }
               //m_canTriggerDown = false;
               m_isPick = false;

               AB_SetState t_set = new N_SetState();
               t_set.fn_setState("level", "0", GetComponent<AB_HandleEvent>());
          }
          public override void fni_putDown()
          {
               //if (m_canTriggerDown)
               //{
               //     return;
               //}
               //base.fni_putDown();
               //fnp_putDown();
               if (m_RemoveRigibody == false)
               {
                    Rigidbody t_rg = GetComponent<Rigidbody>();
                    if (t_rg != null)
                    {
                         t_rg.useGravity = false;
                    }
               }
               FixedJoint t_fj = gameObject.GetComponent<FixedJoint>();
               if (t_fj != null)
               {
                    t_fj.connectedBody = null;
                    //Destroy(t_fj);
               }
               //m_canTriggerDown = false;
               m_isPick = false;
               AB_SetState t_set = new N_SetState();
               t_set.fn_setState("level", "2", GetComponent<AB_HandleEvent>());

          }
          protected void fnp_canTriggerDown()
          {
               //m_canTriggerDown = false;
               GetComponent<N_FusePutIn>().m_useTrigger = true;
          }
     }

}