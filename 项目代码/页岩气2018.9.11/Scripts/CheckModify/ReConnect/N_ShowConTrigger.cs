using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 零件对应的机器上的放入触发器的显示和隐藏
     /// 2018.5.18--需要加入条件的检查才能显示触发器
     /// </summary>
     public class N_ShowConTrigger : AB_ShowConTrigger
     {
         
          protected virtual void Start() {
               AB_ThePart t_thepart = GetComponent<AB_ThePart>();
               if (t_thepart!=null)
               {
                    t_thepart.M_PartStateChangeEvent += fn_ReceiveEvent;
               }
          }
          public override void fn_ShowOrHide(bool _show = true)
          {
               AB_NameFlag t_nameflag = GetComponent<AB_NameFlag>();
               if (t_nameflag==null)
               {
                    Debug.Log("<color=red>not find AB_NameFlag</color>");
     
                    return;
               }
               AB_PullOut t_pullout = S_PullOutPart.Instance.fn_getPullOut(t_nameflag.M_nameID);
               if (t_pullout==null)
               {
                    Debug.Log("<color=red>not find AB_PullOut</color>");
                    return;
               }
               if (_show)
               {//在显示的时候需要检查零件的安装顺序
                    AB_Condition t_condition =t_pullout.gameObject.GetComponent<AB_Condition>();
                    if (t_condition != null)
                    {
                         if (t_condition.fn_check("canPutIn")==false)
                         {
                              return;
                         }
                    }
                    else
                    {
                         Debug.Log("<color=red>not find AB_Condition</color>");
                    }
               }
               t_pullout.fn_BackTrigger(_show);

          }

          protected override void fn_ReceiveEvent(E_ThePartState _state)
          {
              //如果在手上，那么1秒钟后显示放入触发器
               if (_state== E_ThePartState.e_inHand)
               {
                    Invoke("fnp_show", 1f);
               }
               else
               {
                    CancelInvoke("fnp_show");
                    fn_ShowOrHide(false);
               }
          }
          /// <summary>
          /// 显示装入提示球
          /// </summary>
          protected virtual void fnp_show()
          {
               fn_ShowOrHide();
          }

        
     } 
}
