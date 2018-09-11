using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class testPutIn : AB_YaobaTrigger
     {
          /// <summary>
          /// 初始化的链接物体
          /// </summary>
          public GameObject m_ConnectObj = null;
          protected AB_FuseState m_thisFuseState = null;
          protected virtual void Start()
          {
               m_thisFuseState = GetComponent<AB_FuseState>();
               if (m_ConnectObj != null)
               {//如果一开始就链接熔断器的情况
                    Rigidbody t_rg = GetComponent<Rigidbody>();
                    if (t_rg != null)
                    {
                         t_rg.useGravity = false;
                    }
                    fnp_connect(m_ConnectObj.transform);
                    AB_haveFuse t_havefuse = m_ConnectObj.GetComponent<AB_haveFuse>();
                    if (t_havefuse != null)
                    {
                         t_havefuse.fn_connectFuse(true);
                    }
                    AB_FuseState t_otherFuseState = m_ConnectObj.GetComponent<AB_FuseState>();
                    //传入熔断器是否可用
                    t_otherFuseState.fn_setState(m_thisFuseState.fn_CanWork());
                    //熔断器卡槽的编号
                    AB_Name t_othernameid = m_ConnectObj.GetComponent<AB_Name>();
                    AB_NameFlag t_name = GetComponent<AB_NameFlag>();
                    t_name.M_nameID = t_othernameid.m_ID;
                    m_useTrigger = false;
               }

          }
          public override void fnp_reset()
          {
               throw new System.NotImplementedException();
          }

          protected override void fnp_putIn()
          {
               //Rigidbody t_rg = GetComponent<Rigidbody>();
               I_pickUp t_pickup = GetComponent<I_pickUp>();
               if (t_pickup != null)
               {
                    t_pickup.fni_putDown();
               }
               //if (t_rg != null)
               //{
               //     t_rg.isKinematic = true;
               //}
          }
          public bool m_useTrigger = true;
          //public bool m_connectStart = false;
          public void OnTriggerEnter(Collider other)
          {
               if (m_useTrigger == false)
               {//碰撞不可用的时候
                    return;
               }
               //Debug.Log("<color=red>red:</color>");

               if (other.tag == "putin")
               {
                    bool t_canputin = true;
                    AB_haveFuse t_havefuse = other.gameObject.GetComponent<AB_haveFuse>();
                    AB_FuseState t_otherFuseState = other.gameObject.GetComponent<AB_FuseState>();
                    if (t_havefuse != null)
                    {
                         t_canputin = t_havefuse.fn_HaveFuse();
                    }
                    if (t_canputin == false)
                    {
                         m_useTrigger = false;
                         //放入熔断器卡槽
                         fnp_putIn();
                         //对齐位置，链接
                         fnp_connect(other.gameObject.transform);
                         //告诉熔断器卡槽有容电器接入
                         t_havefuse.fn_connectFuse(true);
                         //传入熔断器是否可用
                         t_otherFuseState.fn_setState(m_thisFuseState.fn_CanWork());
                         //熔断器卡槽的编号
                         AB_Name t_othernameid = other.gameObject.GetComponent<AB_Name>();
                         AB_NameFlag t_name = GetComponent<AB_NameFlag>();
                         t_name.M_nameID = t_othernameid.m_ID;
                         t_othernameid = GetComponent<AB_Name>();
                         //发送熔断器放入卡槽的消息
                         AB_SendMsg t_sendmsg = new N_SendMsg();
                         t_sendmsg.fn_sendmsg(E_MessageType.e_inside, E_valueType.e_inter_onoff,
                              t_othernameid.m_ID, t_name.M_nameID, "on", GetComponent<AB_HandleEvent>());
                    }
                    else
                    {
                         return;
                    }

               }
          }

          private void fnp_connect(Transform other)
          {
               gameObject.transform.position = other.position;
               gameObject.transform.rotation = other.rotation;
               FixedJoint t_fj = gameObject.GetComponent<FixedJoint>();
               if (t_fj == null)
               {
                    t_fj = gameObject.AddComponent<FixedJoint>();
               }
               if (t_fj != null)
               {
                    t_fj.connectedBody = other.gameObject.GetComponent<Rigidbody>();
               }
          }
     }

}