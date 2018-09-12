using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 阀座拉出器的触发器，用于触发定位用
     /// </summary>
     public class N_PullerTrigger : N_YaobaTrigger
     {
          public override void OnTriggerEnter(Collider other)
          {
               AB_ToolHavePart t_tool = GetComponent<AB_ToolHavePart>();
               if (t_tool != null)
               {//防止工具有零件还能被使用的情况
                    if (t_tool.M_tollHavePart == E_ToolHavePart.e_havePart)
                    {
                         return;
                    }
               }
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

                    fnp_Do(other.gameObject);

                    gameObject.transform.rotation = other.gameObject.transform.rotation;
                    gameObject.transform.position = other.gameObject.transform.position;
                    //
                    fnp_putIn();



               }



          }
          /// <summary>
          /// 检查碰触物体上的其他组件
          /// </summary>
          protected virtual void fnp_Do(GameObject _collider)
          {

          }
     } 
}
