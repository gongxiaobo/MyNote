using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{
     /// <summary>
     ///只处理了90度的旋转情况
     /// </summary>
     public class N_RotateByPart : AB_RotateByPart
     {
          /// <summary>
          /// 旋转的轴
          /// </summary>
          public Vector3 m_axis = new Vector3(0f, 1f, 0f);
          /// <summary>
          /// 处理了90旋转的情况
          /// </summary>
          /// <param name="_angle"></param>
          public override void fn_Rotate(float _angle)
          {
               m_rotate = ((_angle >= 0f) ? _angle : (_angle + 90f));
               Vector3 t_rotate = m_axis * m_rotate;
               gameObject.transform.DORotate(t_rotate, 0.1f);
          }
          [SerializeField]
          float m_rotate = 0f;
          public override float M_Rotate
          {
               get
               {
                    return m_rotate ;
               }
               set
               {
                    m_rotate=value;
               }
          }
     }
}
