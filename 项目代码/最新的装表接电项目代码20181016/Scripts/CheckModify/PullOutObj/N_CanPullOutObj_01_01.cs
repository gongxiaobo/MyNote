using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 独立出来后链接到工具上
     /// </summary>
     public class N_CanPullOutObj_01_01 : N_CanPullOutObj_01, I_ToolObjToPart
     {
          /// <summary>
          /// 零件独立出来后的触发器是否是被其他物体激活才能使用
          /// </summary>
          public bool m_partTriggerBeSet = false;
          /// <summary>
          /// 工具物体
          /// </summary>
          public GameObject m_ConnectTool = null;
          public override void fn_ToIndependent(GameObject _parent)
          {
               if (m_ConnectTool==null)
               {
                    Debug.Log("<color=red>tool obj ==null</color>");
                    return;
               }
               //base.fn_ToIndependent(_parent);
               if (m_isIndependent)
               {
                    return;
               }
               m_isIndependent = true;

               if (m_parent==null)
               {
                    m_parent = _parent; 
               }
               //if (GetComponent<N_PickUp>() == null)
               //{
               //     gameObject.AddComponent<N_PickUp>();
               //}
               //唤醒碰撞体
               if (m_box != null && m_partTriggerBeSet==false)
               {
                    m_box.SetActive(true);
               }
               gameObject.transform.parent = m_ConnectTool.transform;
               fnp_setToolHavePart(E_ToolHavePart.e_havePart);
               //添加拾取组件，注册反馈
               I_PickUpFromTool t_callback=gameObject.AddComponent<N_PickUp_01>();
               t_callback.fni_PickUpPartFromTool(fnp_BePickUpFromTool);
               //加入声音
               fnp_addSound();
               //gameObject.transform.position =
               //     S_HandButton.Instance.GetRigid.fni_getHandRigid().transform.position;

               ////刷新最近物体
               //GlobalEventSystem<GE_refleshFindNearObj>.Raise(new GE_refleshFindNearObj());
               //Invoke("fnp_reconnect", 0.01f);
          }
          /// <summary>
          /// 对于工具上的有无零件的状态改变
          /// </summary>
          /// <param name="_state"></param>
          private void fnp_setToolHavePart(E_ToolHavePart _state)
          {
               if (m_ConnectTool == null)
               {
                    Debug.Log("<color=red>tool obj ==null</color>");
                    return;
               }
               //设置工具上已经有零件的状态
               AB_ToolHavePart t_toolhavepart = m_ConnectTool.GetComponent<AB_ToolHavePart>();
               if (t_toolhavepart != null)
               {
                    t_toolhavepart.M_tollHavePart = _state;
               }
          }
          /// <summary>
          /// 当零件被从工具上拿出的回调
          /// </summary>
          protected void fnp_BePickUpFromTool()
          {
               fnp_setToolHavePart(E_ToolHavePart.e_noPart);
          }

          

          #region I_ToolObjToPart
          public void fni_ToolObjToPart(GameObject _tool)
          {
               if (_tool != null)
               {
                    m_ConnectTool = _tool;
               }
               else
               {

                    Debug.Log("<color=red>_tool==null</color>");
               }
          } 
          #endregion
     } 
}
