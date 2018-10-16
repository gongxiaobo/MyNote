using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 线的颜色
     /// 处理双色线的情况
     /// 处理循环选择的情况
     /// 927:处理对虚拟item的赋值
     /// </summary>
     public class N_UILevel01_03 : N_UILevel01
     {

          public List<E_ropeColor> m_ropes = new List<E_ropeColor>();
          public List<Color> m_colors = new List<Color>();
          public E_ropeColor m_ropesize = E_ropeColor.e_red;
          /// <summary>
          /// 把枚举转换成其他名称的数据
          /// </summary>
          public N_UIdata m_name;
          int m_modeId = 0;
          protected override void Start()
          {
               base.Start();
               if (m_image==null)
               {
                    m_image=GetComponent<Image>();
               }
               Transform t_othercolor= transform.FindInChild("downcolor");
               if (m_imageChild==null)
               {
                    m_imageChild = t_othercolor.GetComponent<Image>();
               }
               fnp_showColor();
          }
          public override void fni_receive(SMsg _reveive)
          {
               //base.fni_receive(_reveive);
               
               //Debug.Log("<color=blue>改变颜色</color>"+_reveive.m_ID);
     
               if (_reveive.m_ID == m_UIID)
               {//当消息是自己发出，不处理
                    return;
               }
               if (_reveive.m_ID == 5)
               {
                    m_modeId--;
                    if (m_modeId < 0)
                    {
                         m_modeId = 4;
                    }
               }
               if (_reveive.m_ID == 4)
               {
                    m_modeId++;
                    if (m_modeId >= (m_ropes.Count))
                    {
                         m_modeId = 0;
                    }
               }
               m_ropesize = m_ropes[m_modeId];
               fnp_showColor();
          }
          Image m_image = null;
          Image m_imageChild = null;
          protected void fnp_showColor()
          {
               if (m_modeId!=4)
               {
                    if (m_image != null)
                    {
                         m_image.color = m_colors[m_modeId];
                    }
                    if (m_imageChild!=null)
                    {
                         m_imageChild.color = m_colors[m_modeId];
                    }
               }
               else
               {
                    if (m_image != null)
                    {
                         m_image.color = m_colors[3];
                    }
                    if (m_imageChild != null)
                    {
                         m_imageChild.color = m_colors[1];
                    }
               }
               if (m_name!=null)
               {
                    S_selectUI.Instance.m_ropecolor =
                              m_name.m_datas[(int)m_ropesize].m_codeName;
                    //新手引导使用,对虚拟按钮的赋值
                    if (S_SceneMessage.Instance.m_TableMode== Assets.Scripts.Connection.TableMode.E_TableMode.e_newbird)
                    {
                         int t_id;
                         if (int.TryParse("5510", out t_id))
                         {
                              GameObject t_item = S_SceneMagT1.Instance.fn_getItemObj(t_id);
                              if (t_item != null)
                              {
                                   AB_SetState t_set = new N_SetState();
                                   t_set.fn_setState("string", S_selectUI.Instance.m_ropecolor, t_item.GetComponent<AB_HandleEvent>());
                              }
                         } 
                    }

               }
          }
     } 
}
