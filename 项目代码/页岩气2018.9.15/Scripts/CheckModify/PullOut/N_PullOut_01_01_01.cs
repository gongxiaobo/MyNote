using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 在处理零件放入使用工具的情况，打开工具触发器
     /// 处理使用工具放入到机器，零件到达最小值时的脱离工具处理
     /// </summary>
     public class N_PullOut_01_01_01 : N_PullOut_01_01, I_SetPullBack
     {
          public override void fn_activation()
          {
             
               AB_UseTool t_useTool = GetComponent<AB_UseTool>();
               AB_State t_state = GetComponent<AB_State>();

               if (t_state != null)
               {
                    if (t_state.fn_getMainValue() == "havepart")
                    {
                         base.fn_activation();

                    }
                    else
                    {
                         if (t_useTool.M_UseTool== E_UseTool.e_UseToolAll)
                         {
                              //如果没有零件，
                              fnp_findSpanner();

                              if (m_spanner != null)
                              {
                                   S_update.Instance.M_update = fnp_update;
                              } 
                         }
                    }
               }
               

               

          }
          public override void fn_Trigger(bool _onoff)
          {
               //base.fn_Trigger(_onoff);
               if (m_MoveHanderTrigger != null)
               {
                    AB_UseTool t_usetool = GetComponent<AB_UseTool>();
                    if (t_usetool != null)
                    {
                         if (t_usetool.M_UseTool == E_UseTool.e_UseToolAll)
                         {
                              //m_MoveHanderTrigger.SetActive(false);
                              if (_onoff)
                              {//把放入零件的触发器打开
                                   //需要关闭工具的触发器，关闭后不响应工具的触发
                                   AB_Name t_name = GetComponent<AB_Name>();
                                   if (t_name != null)
                                   {
                                        S_ToolTrigger.Instance.fn_SetToolPushTrigger(t_name.m_ID, _onoff);
                                   }
                                   else
                                   {

                                        Debug.Log("<color=red>not find AB_Name!</color>");

                                   }
                              }
                         }
                         else
                         {
                              m_MoveHanderTrigger.SetActive(_onoff);
                         }
                    }
                   
               }
               if (_onoff)
               {
                    fnp_showArrowTip(true, true);
               }
               else
               {//在吧零件放入到机器后，关闭箭头指示
                    fnp_showArrowTip(false);
               }
          }
         
          protected override void fnp_update()
          {
               //base.fnp_update();
              
               if (m_spanner != null)
               {

                    //Debug.Log("<color=blue>check:</color>");

                    if (m_spanner.fni_valueToBig())
                    {//到达最大值
                         if (m_pullout)
                         {
                              return;
                         }
                         //工具结束控制
                         m_spanner.fn_endControl();

                         fn_PullOut();
                         m_pullout = true;
                         S_update.Instance.fn_remove(fnp_update);

                         //Debug.Log("<color=red>red:</color>");

                    }
                    if (m_spanner.fni_valueToSmall())
                    {//到达最小值时
                         //Debug.Log("<color=blue>check1:</color>");
                         if (m_pullout==false)
                         {
                              return;
                         }
                         if (m_pullout)
                         {
                              if (m_isFlip)
                              {
                                   fnp_showArrowTip(false);
                                   m_isActive = false;
                              }
                              //工具结束控制
                              m_spanner.fn_endControl();
                              m_pullout = false;
                              S_update.Instance.fn_remove(fnp_update);
                              //还需要把零件放入到机器内部的操作


                              //Debug.Log("<color=red>到达最小值时,取出工具</color>");
     

                         }
                    }
               }
          }
          /// <summary>
          /// 设置m_pullout的状态值，为了工具和零件的脱离
          /// </summary>
          /// <param name="_state">true 为放入零件的工具脱离</param>
          public void fni_setPullBack(bool _state)
          {
               AB_State t_state = GetComponent<AB_State>();
               if (t_state.fn_getMainValue() == "nopart")
               {
                    m_pullout = _state;
               }
              
          }
     } 
     
}
