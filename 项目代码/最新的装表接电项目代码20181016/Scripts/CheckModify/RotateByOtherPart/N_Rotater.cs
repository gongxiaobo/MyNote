using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 找到要旋转的零件，然后旋转
     /// </summary>
     public class N_Rotater : AB_Rotater
     {
          AB_RotateByPart m_rotatePart = null;
          public override void fn_Rotate(float _angle)
          {
               if (m_rotatePart==null)
               {//根据ID找到零件
                    if (M_PartID==0)
                    {
                         return;
                    }
                    Transform t_part = S_SceneMagT1.Instance.fni_ItemPos(M_PartID);
                    if (t_part!=null)
                    {
                         m_rotatePart = t_part.GetComponent<AB_RotateByPart>();
                    }
                    else
                    {
                         return;
                    }

               }
               if (m_rotatePart == null)
               {
                    return;
               }
               m_rotatePart.fn_Rotate(_angle);
          }
          [Tooltip("需要被旋转的零件编号")]
          public int m_partID = 0;
          public override int M_PartID
          {
               get
               {
                    return m_partID;
               }
               set
               {
                    m_partID=value;
               }
          }
     } 
}
