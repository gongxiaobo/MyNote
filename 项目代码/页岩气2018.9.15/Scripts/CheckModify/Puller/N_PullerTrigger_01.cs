using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 拉出器的触发时的工作准备
     /// 设置动画的初始位置
     /// </summary>
     public class N_PullerTrigger_01 : N_PullerTrigger
     {

          protected override void fnp_Do(GameObject _collider)
          {
               base.fnp_Do(_collider);

               
               //设置工具动画的初始位置
               AB_RotateRange t_AniTime = _collider.GetComponent<AB_RotateRange>();
               AB_SpAni t_columnAni = GetComponentInChildren<AB_SpAni>();
               if (t_AniTime != null && t_columnAni != null)
               {
                    t_columnAni.fn_setAniTime(t_AniTime.M_AniTime.x);

               }
               else
               {
                    throw new  System.NotImplementedException();
               }
               AB_AnimationAdd t_animationAdd = GetComponentInChildren<AB_AnimationAdd>();
               if (t_animationAdd != null && t_AniTime != null)
               {//设置动画播放的起始位置
                    t_animationAdd.M_AniStartTime = t_AniTime.M_AniTime.x;
                    //设置动画的目标位置
                    t_animationAdd.M_SetEndAniTime = t_AniTime.M_AniTime.y;
               }
               else
               {
                    throw new System.NotImplementedException();
               }
               //隐藏触发器
               //_collider.gameObject.GetComponent<Box>
               AB_NameFlag t_nf = _collider.GetComponent<AB_NameFlag>();
               if (t_nf!=null)
               {
                  AB_ToolTriggerInfo t_info=
                       S_ToolTrigger.Instance.fn_getToolTrigger(t_nf.M_nameID);
                  if (t_info!=null)
                  {
                       t_info.fn_HideToolTrigger();
                  }
               }
               //找到工具要操作的物体
               AB_ToolTriggerInfo t_toolTrigger = _collider.GetComponent<AB_ToolTriggerInfo>();
               if (t_toolTrigger != null)
               {
                    Transform t_obj = t_toolTrigger.fn_GetControlObj();
                    if (t_obj != null)
                    {//有可操作物体，这个物体对应的零件
                         AB_Spanner t_spanner = t_obj.gameObject.GetComponent<AB_Spanner>();
                         if (t_spanner != null)
                         {
                              //Debug.Log("<color=red>2red:</color>");
                              t_spanner.fn_startControl(m_PartConnectParent.transform);
                         }

                         AB_PullOut t_pullOut = t_obj.gameObject.GetComponent<AB_PullOut>();
                         if (t_pullOut != null)
                         {//激活拉出物体的管理类
                              t_pullOut.fn_activation();
                         }
                         //零件就链接到工具下，方便工具对零件的旋转
                         m_obj = t_obj;
                         if (m_TriggerAndConnect)
                         {
                              Invoke("fnp_callLate", 0.25f);
                              AB_ToolHavePart t_tool = GetComponent<AB_ToolHavePart>();
                              if (t_tool!=null)
                              {
                                   t_tool.M_tollHavePart = E_ToolHavePart.e_havePart;
                              }
                              else
                              {

                                   Debug.Log("<color=red>not find AB_ToolHavePart!</color>");
     
                              }
                         }

                    }
                    t_toolTrigger.M_ToolObj = this.gameObject;
               }
          }
          public bool m_TriggerAndConnect = false;
          /// <summary>
          /// 零件的总父节点
          /// </summary>
          Transform m_obj = null;
          public GameObject m_PartConnectParent = null;
          /// <summary>
          /// 延迟链接到零件下
          /// </summary>
          private void fnp_callLate()
          {
               if (m_obj != null)
               {
                    AB_ThePart t_thePart = m_obj.gameObject.GetComponentInChildren<AB_ThePart>();
                    if (t_thePart != null)
                    {

                         t_thePart.transform.parent = m_PartConnectParent.transform;

                    }
                    m_obj = null;
               }
          }

     } 
}
