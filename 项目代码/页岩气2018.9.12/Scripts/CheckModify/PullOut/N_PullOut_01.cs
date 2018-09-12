using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 实现拉出物体的相关物体的获取
     /// 实现检查拉出物体是否到达拉出位置
     /// 实现断开拉出物体
     /// 实现重新连接被拉出的物体
     /// </summary>
     public class N_PullOut_01 : AB_PullOut,I_PartInDist
     {
          protected virtual void Start() {
               fnp_login();
          }

          private void fnp_login()
          {
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name != null)
               {
                    S_PullOutPart.Instance.fn_login(t_name.m_ID, this);
                    CancelInvoke("fnp_login");
               }
               else
               {
                    InvokeRepeating("fnp_login", 0.5f, 1f);
                    Debug.Log("<color=red>not find AB_Name!</color>");

               }
          }
          //是否激活
          protected bool m_isActive = false;
          protected AB_Spanner m_spanner = null;
          public override void fn_activation()
          {
               if (m_isActive)
               {
                    return;
               }
               m_isActive = true;
               m_pullout = false;
               fnp_findSpanner();

               if (m_spanner!=null)
               {
                    S_update.Instance.M_update = fnp_update;
               }
               //显示指向箭头
               fnp_showArrowTip();

               //Debug.Log("<color=red>activation....</color>"+this.gameObject.name);
               //Invoke("fnp_closeTips",1f);

          }

          protected void fnp_findSpanner()
          {
               if (m_spanner == null)
               {//找到控制物体
                    m_spanner = GetComponent<AB_Spanner>();
               }
               if (m_spanner == null)
               {//找到控制物体
                    m_spanner = GetComponentInChildren<AB_Spanner>();
               }
          }
          /// <summary>
          /// 从最机器中拿出零件，然后放回到机器里，指示箭头不显示
          /// </summary>
          private void fnp_closeTips()
          {
               //到达最小值就消失指示箭头，处理拿出后立马放入机器正确位置
               //已经达到提示效果
               if (m_spanner != null)
               {
                    if (m_spanner.fni_valueToSmall())
                    {
                         fnp_showArrowTip(false);

                    }
               }

               //Debug.Log("<color=red>从最机器中拿出零件，然后放回到机器里，指示箭头不显示</color>");
     
          }

          public override void fn_PullOut()
          {
              
               //if (m_spanner != null)
               //{
               //     m_spanner.fn_endControl();
               //}

               //发送消息给零件的管理类改变状态
               AB_SetState t_setState = new N_SetState();
               t_setState.fn_setState("string", "nopart", GetComponent<AB_HandleEvent>());
               //物体脱离移动轨道
               if (m_controlObj!=null)
               {
                    m_controlObj.transform.parent = null;
               }
               //设置零件的状态
               AB_ThePart t_thepart = M_PullObj.GetComponent<AB_ThePart>();
               if (t_thepart != null)
               {
                    t_thepart.M_PartState = E_ThePartState.e_onGround;
               }
               //父物体不能再被手柄触发，暂时关闭碰撞体
               fn_Trigger(false);
               //刷新最近物体
               GlobalEventSystem<GE_refleshFindNearObj>.Raise(new GE_refleshFindNearObj());
               //让物体自动连接到一个物体上，这里是链接到手柄上
               AB_CanPullOutObj t_outObj = m_controlObj.GetComponent<AB_CanPullOutObj>();
               if (t_outObj!=null)
               {
                    t_outObj.fn_ToIndependent(this.gameObject);
               }
               //需要拿起对应配对的零件才能显示放入位置，所有这里不再拉出后延迟1s激活放入触发器
               //Invoke("fnp_activate", 1f);
              
               //提示箭头关闭显示
               fnp_showArrowTip(false);

               
               //m_isActive = false;
               
          }
          [Tooltip("能被拿出的物体")]
          public GameObject m_controlObj = null;
          public override GameObject M_PullObj
          {
               get { return m_controlObj; }
               set { m_controlObj = value; }
          }
          [Tooltip("是否已经取出零件")]
          [SerializeField]
          protected bool m_pullout = false;
          //检查拉出位置
          protected virtual void fnp_update()
          {
               if ( m_pullout)
               {
                    return;
               }

               Debug.Log("<color=red>检查拉出位置</color>");
     
               if (m_spanner!=null)
               {
                    if (m_spanner.fni_valueToBig())
                    {//到达最大值
                         //手柄结束控制
                         GlobalEventSystem<GE_HandTriggerUp>.Raise(new GE_HandTriggerUp());
                         fn_PullOut();
                         m_pullout = true;
                         S_update.Instance.fn_remove(fnp_update);
                         
                         //Debug.Log("<color=red>red:</color>");
     
                    }
                    if (m_spanner.fni_valueToSmall())
                    {//到达最小值时
                         if (m_isFlip)
                         {
                              fnp_showArrowTip(false);
                              m_isActive = false;
                              //放入零件后就关闭检查
                              S_update.Instance.fn_remove(fnp_update);
                         }
                         
                    }
               }
          }
          [Tooltip("触发器")]
          //移动轨迹的物体触发器
          public GameObject m_MoveHanderTrigger = null;
          [Tooltip("重新连接的触发器")]
          //重新连接的触发器
          public GameObject m_ReCoTrigger = null;
          //开打触发器，给被拉出物体放回到本 物体上的准备工作
          protected virtual void fnp_activate()
          {
               if (m_ReCoTrigger!=null)
               {
                    m_ReCoTrigger.SetActive(true);
               }
               m_isActive = false;
               //设置现在时间轨迹的位置
               fnp_findStartEnd();
               Transform m_reco = m_ReCoTrigger.transform;
               float t_time = Vector3.Distance(m_start.position, m_reco.position) / Vector3.Distance(m_start.position, m_end.position);
               m_spanner.fn_setTo(t_time);

          }

          private void fnp_findStartEnd()
          {
               if (m_start == null)
               {
                    m_start = transform.FindSibling("start");
               }
               if (m_end == null)
               {
                    m_end = transform.FindSibling("end");
               }
          }
          //唤醒碰撞体
          public override void fn_Trigger(bool _onoff)
          {
               if (m_MoveHanderTrigger!=null)
               {
                    m_MoveHanderTrigger.SetActive(_onoff);
               }
               fnp_showArrowTip(true,true);
          }
          protected Transform m_start = null;
          protected Transform m_end = null;
          [Tooltip("箭头指向动画物体")]
          /// <summary>
          /// 箭头指向动画物体
          /// </summary>
          public GameObject m_arrowTip = null;
          protected bool m_isFlip = false;
          protected bool m_tipShowState = false;
          public bool m_showTipsArrow = true;
          /// <summary>
          /// 箭头指向动画的显示和反转功能
          /// </summary>
          /// <param name="_show">是否显示</param>
          /// <param name="_flip">是否反转</param>
          /// <param name="_showModle">是否显示模型</param>
          protected void fnp_showArrowTip(bool _show=true,bool _flip=false,bool _showModle=true)
          {
               if (m_showTipsArrow==false)
               {
                    return;
               }
               if (m_tipShowState==_show)
               {
                    return;
               }
               m_tipShowState = _show;

               fnp_findStartEnd();


               #region ArrowDir
               if (m_ArrowDir == E_ArrowDir.e_z)
               {//+z
                    if (_flip)
                    {//反转是放入零件
                         m_arrowTip.transform.localPosition = m_end.localPosition;
                         m_isFlip = _flip;
                         m_arrowTip.transform.localRotation = Quaternion.AngleAxis(180f, new Vector3(0f, 1f, 0f));
                    }
                    else
                    {//拿出零件
                         m_arrowTip.transform.localPosition = m_start.localPosition;
                         m_isFlip = _flip;
                         m_arrowTip.transform.localRotation = Quaternion.identity;
                    }
               }
               if (m_ArrowDir == E_ArrowDir.e_zb)
               {//-z
                    if (_flip)
                    {//反转是放入零件
                         m_arrowTip.transform.localPosition = m_end.localPosition;
                         m_isFlip = _flip;
                         m_arrowTip.transform.localRotation = Quaternion.identity;
                        
                    }
                    else
                    {//拿出零件
                         m_arrowTip.transform.localPosition = m_start.localPosition;
                         m_isFlip = _flip;
                         m_arrowTip.transform.localRotation = Quaternion.AngleAxis(180f, new Vector3(0f, 1f, 0f)); 
                    }
               }
               if (m_ArrowDir == E_ArrowDir.e_y)
               {//+y
                    if (_flip)
                    {//反转是放入零件
                         m_arrowTip.transform.localPosition = m_end.localPosition;
                         m_isFlip = _flip;
                         m_arrowTip.transform.localRotation = Quaternion.identity;
                         m_arrowTip.transform.localRotation = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
                    }
                    else
                    {//拿出零件
                         m_arrowTip.transform.localPosition = m_start.localPosition;
                         m_isFlip = _flip;
                         m_arrowTip.transform.localRotation = Quaternion.identity;
                         m_arrowTip.transform.localRotation = Quaternion.AngleAxis(-90f, new Vector3(1f, 0f, 0f));
                    }
               } 
               #endregion

               if (_showModle)
               {
                    m_arrowTip.SetActive(_show); 
               }
          }
          [Tooltip("指示箭头的朝向")]
          public E_ArrowDir m_ArrowDir = E_ArrowDir.e_z;

          public override void fn_BackTrigger(bool _onoff)
          {
               fnp_findSpanner();
               if (_onoff)
               {//打开零件放入的提示触发器，打开后零件才能放入到机器上
                    fnp_activate();
               }
               else
               {
                    if (m_ReCoTrigger != null)
                    {
                         m_ReCoTrigger.SetActive(false);
                    }
               }
          }
          /// <summary>
          /// 设置能够操作的触发器
          /// </summary>
          /// <param name="_bl"></param>
          public override void fni_SetPartTrigger(bool _bl)
          {
               //base.fni_SetPartTrigger(_bl);
               if (m_MoveHanderTrigger != null)
               {
                    m_MoveHanderTrigger.SetActive(_bl);

                    Debug.Log("<color=red>m_MoveHanderTrigger =</color>" + _bl+
                         ":name"+GetComponent<AB_Name>().m_ID);
     
               }
          }
          /// <summary>
          /// 零件放入到机器里的距离
          /// </summary>
          /// <returns></returns>
          public float fni_PartInDis()
          {
               return Vector3.Distance(m_start.position, m_ReCoTrigger.transform.position);
          }
     }
}
