using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 是否是拆线
     /// </summary>
     public class N_UILevel01_04 : N_UILevel01
     {
          /// <summary>
          /// true为正在执行拆卸操作
          /// </summary>
          public bool m_isDisLine = false;
          public override void fni_receive(SMsg _reveive)
          {
               base.fni_receive(_reveive);
               if (_reveive.m_ID==10)
               {
                    m_isDisLine = !m_isDisLine;
                    S_selectUI.Instance.m_isDisLine = m_isDisLine;
                    //新手引导使用,对虚拟按钮的赋值
                    if (S_SceneMessage.Instance.m_TableMode == Assets.Scripts.Connection.TableMode.E_TableMode.e_newbird)
                    {
                         int t_id;
                         if (int.TryParse("5512", out t_id))
                         {
                              GameObject t_item = S_SceneMagT1.Instance.fn_getItemObj(t_id);
                              if (t_item != null)
                              {
                                   AB_SetState t_set = new N_SetState();
                                   t_set.fn_setState("onoff", m_isDisLine?"on":"off", t_item.GetComponent<AB_HandleEvent>());
                              }
                         }
                    }     
               }
          }

     } 
}
