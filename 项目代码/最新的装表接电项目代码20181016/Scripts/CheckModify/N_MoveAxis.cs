using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 移动一个物体，每次一小段距离
     /// </summary>
     public class N_MoveAxis : AB_MoveAxis, I_SetMovePara
     {
          protected override void Start()
          {
               base.Start();
               //m_defaultPos = m_move.position;
               if (m_move!=null)
               {
                    N_ToolHavePart_01_01 t_toolhavePart = m_move.GetComponent<N_ToolHavePart_01_01>();
                    if (t_toolhavePart!=null)
                    {
                         t_toolhavePart.m_havePartEvent = fn_reset;
                    }
               }
          }
          ////最开始的位置
          //Vector3 m_defaultPos;
          public override void fn_move(float _moveValue)
          {
               
               //Debug.Log("<color=blue>blue:</color>");
     
               if (m_move!=null)
               {
                    m_moveLength += (m_dir ? 1f : -1f) * m_moveSpace;
                    if (m_moveLength>=m_canMoveLength)
                    {//最大值的时候的设置
                         float t_lastDis = m_moveLength - (m_dir ? 1f : -1f) * m_moveSpace;
                         m_moveLength = m_canMoveLength;
                         m_move.position = fnp_getNextPos(m_move.position, m_canMoveLength - t_lastDis);
                         m_isReachEnd = true;
                         return;
                    }
                    
                    Vector3 t_pos = m_move.position;
                    t_pos = fnp_getNextPos(t_pos, m_moveSpace);
                    m_move.position = t_pos; 
               }
          }

          protected virtual Vector3 fnp_getNextPos(Vector3 t_pos,float _moveSpace)
          {

               //Debug.Log("<color=blue>_moveSpace:</color>" + _moveSpace);
     
               if (m_Axis.x == 1f)
               {
                    t_pos.x += (m_dir ? 1f : -1f) * _moveSpace;
               }
               if (m_Axis.y == 1f)
               {
                    t_pos.y += (m_dir ? 1f : -1f) * _moveSpace;
               }
               if (m_Axis.z == 1f)
               {
                    t_pos.z += (m_dir ? 1f : -1f) * _moveSpace;
               }
               return t_pos;
          }
         
        
          /// <summary>
          /// 被移动的物体
          /// </summary>
          public Transform m_move = null;
          //轴
          public Vector3 m_Axis = new Vector3(0f, 0f, 1f);
          //移动间隔
          public float m_moveSpace = 0.005f;
          protected float m_moveLength = 0f;
          /// <summary>
          /// 可移动的距离
          /// </summary>
          public float m_canMoveLength = 0.01f;


          public override void fn_reset()
          {
               m_moveLength = 0f;
               m_isReachEnd = false;
               //Debug.Log("<color=blue>捶打器复位</color>");
     
          }

          public override Vector3 M_MoveDir
          {
               get
               {
                    return m_Axis;
               }
               set
               {
                    m_Axis=value;
               }
          }

         

          public void fni_set(float _speed, float _length)
          {
               m_canMoveLength = _length;
               m_moveSpace = _speed;
          }
     }

}