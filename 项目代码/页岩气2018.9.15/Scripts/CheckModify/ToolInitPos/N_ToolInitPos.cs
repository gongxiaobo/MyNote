using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 设置柱型工具的位置
     /// </summary>
     public class N_ToolInitPos : AB_ToolInitPos
     {

          public Transform m_toolMove = null;
          public Vector3 m_axis = new Vector3(0f, 1f, 0f);
          public override void fn_setPos(float _pos)
          {
               if (m_toolMove==null)
               {
                    m_toolMove = this.gameObject.transform;
               }
               if (m_toolMove!=null)
               {
                    m_toolMove.localPosition = m_axis * _pos;
               }
          }
          public float m_pos1 = 0.5f, m_pos2 = 0.5f;



          public override void fn_setLevelPos(int _pos)
          {
               if (m_toolMove == null)
               {
                    m_toolMove = this.gameObject.transform;
               }
               if (_pos==1)
               {
                    m_toolMove.localPosition = m_axis * m_pos1;
               }
               else if (_pos==2)
               {
                    m_toolMove.localPosition = m_axis * m_pos2;
               }
          }
     } 
}
