using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把类型的触发器，需要重新定义摇入的角度范围
     /// </summary>
     public class N_YaobaTriggerRangeSet : N_YaobaTrigger
     {
          /// <summary>
          /// 开始接触时，旋把回到0的位置
          /// </summary>
          public bool m_StartBackToZero = true;
          public override void OnTriggerEnter(Collider other)
          {
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
                    if (m_StartBackToZero)
                    {
                         AB_Spanner t_spanner = GetComponentInChildren<AB_Spanner>();
                         if (t_spanner != null)
                         {
                              t_spanner.fn_setTo(0f);
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
                    //如果有音效的，给摇动时的音效赋值
                    I_setRotateSound t_setRotateSound = GetComponentInChildren<I_setRotateSound>();
                    if (t_setRotateSound != null)
                    {
                         t_setRotateSound.fni_SetSoundName(t_rt.M_SoundName);
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
