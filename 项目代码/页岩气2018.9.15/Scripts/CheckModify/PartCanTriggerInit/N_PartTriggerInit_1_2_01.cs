using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理在初始化零件放入到机器内部是安装好的情况下是旋转90度
     /// </summary>
     public class N_PartTriggerInit_1_2_01 : N_PartTriggerInit_1_2
     {
          /// <summary>
          /// 旋转的轴
          /// </summary>
          public Vector3 m_axis = new Vector3(0f, 1f, 0f);
          public float m_rotate = 90f;
          protected override void fnp_DoInit()
          {
               base.fnp_DoInit();
               AB_State t_state = GetComponent<AB_State>();
               if (t_state!=null)
               {
                    if (t_state.fn_getMainValue() == "nopart")
                    {

                    }
                    else
                    {//零件在机器里需要旋转90度才算是装入到机器内部

                         Vector3 t_rotate = m_axis * m_rotate;
                         gameObject.transform.DORotate(t_rotate, 0.1f);
                    }
               }
          }

     } 
}
