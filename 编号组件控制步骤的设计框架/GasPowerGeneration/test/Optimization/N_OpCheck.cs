using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.test.Optimization
{
     /// <summary>
     /// 自定义的距离剔除工具，对于配置好的可以剔除的物体
     /// 会根据距离来剔除可隐藏的物体，达到节约GPU和CPU的资源消耗
     /// 理想情况可以达到节约50%的消耗
     /// </summary>
     public class N_OpCheck : AB_OpCheck
     {
          protected override void Start()
          {
               base.Start();
               fnp_findObj();
               S_OpMesh.Instance.M_OpCheck = this;
              
          }

          Transform m_playerPos = null;
          public override Transform M_player
          {
               get
               {
                    return m_playerPos ;
               }
               set
               {
                    m_playerPos = value ;
               }
          }

          public override void fn_SetImmediately(Vector3 _playerWorldPos)
          {
               if (m_isCloseOptimizan)
               {
                    return;
               }
               //Vector3 t_pos = _playerWorldPos;
               //if (_playerWorldPos.y!=0f)
               //{
               //     t_pos = new Vector3(_playerWorldPos.x, 0f, _playerWorldPos.z);
               //}
               fnp_check(_playerWorldPos);
          }
          public float m_showLength = 2.5f;

          private void fnp_check(Vector3 _pos)
          {
               if (m_Objs.Count == 0)
               {
                    return;
               }
               //主动更新要覆盖自动更新显示的操作
               CancelInvoke("fnp_endDelay");
               m_delay = true;
               Invoke("fnp_endDelay", 1f);
               //if (m_playerPos == null)
               //{
               //     return;
               //}

               for (int i = 0; i < m_Objs.Count; i++)
               {
                    AB_HideRange t_hiderange = m_Objs[i].GetComponent<AB_HideRange>();
                    if (t_hiderange != null)
                    {//特殊范围
                         fnp_checkRange(_pos, i, t_hiderange.M_range);
                         continue;
                    }
                    //普通范围
                    fnp_checkRange(_pos, i, m_showLength);
               }
          }
          protected virtual void fnp_checkOnSecond()
          {
               //Debug.Log("<color=blue>check</color>");
               if (m_isCloseOptimizan)
               {
                    return;
               }
               if (m_delay)
               {
                    return;
               }
               if (m_Objs.Count == 0)
               {
                    return;
               }
               if (m_playerPos == null)
               {
                    return;
               }
               Vector3 t_pos = m_playerPos.position;
               //if (t_pos.y != 0f)
               //{
               //     t_pos = new Vector3(t_pos.x, 0f, t_pos.z);
               //}
               for (int i = 0; i < m_Objs.Count; i++)
               {
                    AB_HideRange t_hiderange = m_Objs[i].GetComponent<AB_HideRange>();
                    if (t_hiderange != null)
                    {//特殊范围
                         fnp_checkRange(t_pos, i, t_hiderange.M_range);
                         continue;
                    }
                    //普通范围
                     fnp_checkRange(t_pos, i, m_showLength);
                    
               }

//#if UNITY_EDITOR
//               Debug.Log("<color=blue>check</color>" + m_Objs.Count); 
//#endif
     
          }

          private void fnp_checkRange(Vector3 t_pos, int i, float _hiderange)
          {
               if (Vector3.Distance(m_Objs[i].position, t_pos) <= _hiderange)
               {//显示
                    S_OpMesh.Instance.fn_HideOrShow(m_Objs[i].name, true);
               }
               else
               {//不显示
                    S_OpMesh.Instance.fn_HideOrShow(m_Objs[i].name, false);
               }
              
          }
          //Dictionary<string, Transform> m_Obj = new Dictionary<string, Transform>();
          List<Transform> m_Objs = new List<Transform>();
          //找到管理物体下方的所有关系节点
          protected virtual void fnp_findObj()
          {
               Transform[] t_child = GetComponentsInChildren<Transform>();
               for (int i = 0; i < t_child.Length; i++)
               {
                    //if (t_child[i].name==this.gameObject.name)
                    //{
                    //     continue;
                    //}
                    //if (m_Obj.ContainsKey(t_child[i].name))
                    //{
                         
                    //     Debug.Log("<color=red>same name ! be carefully</color>");
                    //     continue;
     
                    //}
                    //m_Obj.Add(t_child[i].name, t_child[i]);
                    m_Objs.Add(t_child[i]);
               }
          }
          /// <summary>
          /// 关闭优化功能
          /// </summary>
          public bool m_isCloseOptimizan = false;
          public override bool M_CloseOptimizam
          {
               set { m_isCloseOptimizan=value; }
          }

          public override void fn_startCheck()
          {
               InvokeRepeating("fnp_checkOnSecond", 1f, 1f);
          }

          public override void fn_endCheck()
          {
               CancelInvoke("fnp_checkOnSecond");
          }
          /// <summary>
          /// 延迟自动优化时间
          /// 主要作用是避开自动和主动的优化冲突
          /// </summary>
          protected bool m_delay = false;
          /// <summary>
          /// 取消延迟，正常刷新
          /// </summary>
          protected void fnp_endDelay()
          {
               m_delay = false;
          }

     }
}
