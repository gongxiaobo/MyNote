using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 拉出的物体，创建可以拾取的类，主动请求挂载到手柄下
     /// 完成从轨迹移动出来后，挂载到手柄的过程
     /// </summary>
     public class N_CanPullOutObj_01 : AB_CanPullOutObj,I_PullOutPart
     {
          //链接回本来的位置的父节点
          protected GameObject m_parent = null;
          //碰撞体
          public GameObject m_box = null;
          protected override void Start()
          {
               base.Start();
               AB_ThePart t_thepart=GetComponent<AB_ThePart>();
               if (t_thepart!=null)
               {
                    if (m_box != null)
                    {
                         m_box.SetActive((t_thepart.M_PartState== E_ThePartState.e_inMachine)?false:true);
                    } 
               }
               
          }
          protected bool m_isIndependent = false;
          /// <summary>
          /// 断开和父节点的链接，独立成为一个整体，可以被拾取
          /// </summary>
          /// <param name="_parent"></param>
          public override void fn_ToIndependent(GameObject _parent)
          {
               if (m_isIndependent)
               {
                    return;
               }
               
               Debug.Log("<color=blue>物体独立</color>");
     
               //唤醒碰撞体
               if (m_box != null)
               {
                    m_box.SetActive(true);
               }
               if (GetComponent<N_PickUp_02>() == null)
               {
                    gameObject.AddComponent<N_PickUp_02>();
               }
               m_isIndependent = true;
     
               m_parent = _parent;

               //GUILayout.Label("good");
               gameObject.transform.position=
                    S_HandButton.Instance.GetRigid.fni_getHandRigid().transform.position;
              
               //刷新最近物体
               GlobalEventSystem<GE_refleshFindNearObj>.Raise(new GE_refleshFindNearObj());
               fnp_addSound();
               Invoke("fnp_reconnect", 0.015f);
          }

          protected void fnp_addSound()
          {
               AB_ColliderSound t_cs = GetComponent<AB_ColliderSound>();
               if (t_cs == null)
               {
                    gameObject.AddComponent<N_ColliderSound>();
               }
          }
          /// <summary>
          /// 单独立物体离开原来父节点后，在等待0.01s后再次链接到手柄上
          /// </summary>
          protected void fnp_reconnect()
          {
               GlobalEventSystem<GE_HandTriggerDown>.Raise(new GE_HandTriggerDown());
               Debug.Log("<color=blue>物体链接到手柄上</color>");
          }
          /// <summary>
          /// 断开和手柄的链接，回到原来物体上
          /// </summary>
          public override void fn_ToAttach()
          {
               //找到要链接机器的节点
               AB_NameFlag t_nf = GetComponent<AB_NameFlag>();
               AB_PullOut t_po = S_PullOutPart.Instance.fn_getPullOut(t_nf.M_nameID);
               if (m_parent==null)
               {//找到零件相同编号的机器位置父节点
                    if (t_po!=null)
                    {
                         m_parent = t_po.gameObject;
                    }
               }
               if (m_parent==null)
               {
                    Debug.Log("<color=red>不能再次链接，没有可链接的物体</color>");
                    return;
               }

               //Debug.Log("<color=blue>blue:</color>" + m_parent.name);
     
               //断开和手柄的链接
               GlobalEventSystem<GE_HandTriggerDown>.Raise(new GE_HandTriggerDown());
               Destroy(GetComponent<FixedJoint>());
               //移除链接组件
               Destroy(GetComponent<Rigidbody>());
               if (GetComponent<N_PickUp_01>()!=null)
               {
                    Destroy(GetComponent<N_PickUp_01>());
               }
               if (GetComponent<N_PickUp>() != null)
               {
                    Destroy(GetComponent<N_PickUp>());
               }
               //Destroy(GetComponent<N_PickUp>());
               gameObject.transform.parent = m_parent.transform;
               gameObject.transform.localPosition = Vector3.zero;
               gameObject.transform.localRotation = Quaternion.identity;
               //唤醒碰撞体
               if (m_box != null)
               {
                    m_box.SetActive(false);
               }
               //唤醒父节点的碰撞体
               //AB_PullOut t_pullout = m_parent.GetComponent<AB_PullOut>();
               if (t_po != null)
               {
                    t_po.fn_Trigger(true);
                    //告诉机器现在的安装的零件物体是哪一个
                    t_po.M_PullObj = this.gameObject;
               }
               m_isIndependent = false;
               //手柄结束控制,主要是拉起物体时扳机键按下和弹起完成一次对拿起物体的操作
               GlobalEventSystem<GE_HandTriggerUp>.Raise(new GE_HandTriggerUp());
               //
          }

          #region I_PullOutPart

          public void fni_setTrigger(bool _bl)
          {
               //唤醒碰撞体
               if (m_box != null)
               {
                    m_box.SetActive(_bl);
               }
          }
          #endregion
     }
}
