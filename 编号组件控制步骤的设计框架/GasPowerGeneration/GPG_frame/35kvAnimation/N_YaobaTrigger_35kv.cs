using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 为了处理35kv的的摇把初始化问题，
     /// 当摇把碰到链接点后，查找链接点的当前动画值，然后根据动画值设置摇把的旋转位置。
     /// </summary>
     public class N_YaobaTrigger_35kv : N_YaobaTrigger
     {
          /// <summary>
          /// 使用对应的item的值来设置现在摇把的旋转位置。
          /// </summary>
          public bool m_setAngelUseStateValue = true;
          public override void OnTriggerEnter(Collider other)
          {

               //Debug.Log("<color=blue>为了处理35kv的的摇把初始化问题，</color>");

               //base.OnTriggerEnter(other);
               if (m_isPutIn)
               {
                    return;
               }
               if (other.tag == "yaoba")
               {
                    AB_NameFlag t_nf = other.gameObject.GetComponent<AB_NameFlag>();
                    AB_NameFlag t_nf1 = GetComponent<AB_NameFlag>();
                    if (t_nf != null && t_nf1 != null)
                    {
                         if (t_nf.Me_Type != t_nf1.Me_Type)
                         {//如果类型不一样，那么不能操作
                              return;
                         }
                         t_nf1.M_nameID = t_nf.M_nameID;
                    }
                    else
                    {
                         return;
                    }
                    //设置角度范围
                    I_RealtimeSetRange ti_rs = GetComponentInChildren<I_RealtimeSetRange>();
                    AB_RotateRange t_rt = other.gameObject.GetComponent<AB_RotateRange>();
                    if (ti_rs != null && t_rt != null)
                    {
                         ti_rs.fni_setRange(t_rt.M_getRange);
                    }
                    //设置把手回到开始位置
                    //if (m_StartBackToZero)
                    //{
                    //     AB_Spanner t_spanner = GetComponentInChildren<AB_Spanner>();
                    //     if (t_spanner != null)
                    //     {
                    //          t_spanner.fn_setTo(0f);
                    //     }
                    //}
                    if (m_setAngelUseStateValue)
                    {
                         //找到当前关联的物体的旋转值
                         I_CheckValue ti_getIDvalue = S_SceneMagT1.Instance;
                         string t_value = ti_getIDvalue.fni_checkDate(GetComponent<AB_NameFlag>().M_nameID);

                         //Debug.Log("<color=blue>当前的动画值</color>" + t_value);

                         if (t_value != "")
                         {
                              float t_setvalue;
                              bool t_canuse = float.TryParse(t_value, out t_setvalue);
                              if (t_canuse)
                              {//设置把手的旋转角度值
                                   AB_Spanner t_spanner = GetComponentInChildren<AB_Spanner>();
                                   if (t_spanner != null)
                                   {//这里使用的最大值，这种使用只能在【0，max】这种范围下才有效
                                        t_spanner.fn_setTo(t_rt.M_getRange.y * t_setvalue);
                                   }
                              }
                         }
                    }
                    //设置是否停止操作自动弹回到0位置
                    I_YaobaBackSet t_ybs = GetComponent<I_YaobaBackSet>();
                    if (t_rt != null && t_ybs != null)
                    {
                         t_ybs.fni_setCanBack(t_rt.M_Back);
                    }
                    //设置是否在最小值时发送消息的接口设置
                    I_setBool ti_setBool = GetComponent<I_setBool>();
                    if (ti_setBool != null)
                    {
                         ti_setBool.fni_setsmall(t_rt.M_ValueSmallSendMsg);
                         ti_setBool.fni_setbig(t_rt.M_ValueBigSendMsg);
                         ti_setBool.fni_setflip(t_rt.M_SendValueFlip);
                    }


                    //

                    gameObject.transform.rotation = other.gameObject.transform.rotation;
                    gameObject.transform.position = other.gameObject.transform.position;
                    //
                    fnp_putIn();



               }
          }

     }

}