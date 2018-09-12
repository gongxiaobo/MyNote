using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
using System.Threading;
using GasPowerGeneration;
namespace Assets.Scripts.test.Optimization
{
     /// <summary>
     /// 优化网格的可以隐藏的物体的统一归类
     /// 赋值显示和隐藏
     /// </summary>
     public class S_OpMesh : GenericSingletonClass<S_OpMesh>
     {
          protected Dictionary<string, List<AB_OpMesh>> m_OpMeshs = new Dictionary<string, List<AB_OpMesh>>();
          protected Dictionary<string, bool> m_OpMeshsState = new Dictionary<string, bool>();
          public void fn_login(string _name, AB_OpMesh _op)
          {
               if (m_OpMeshs.ContainsKey(_name))
               {
                    m_OpMeshs[_name].Add(_op);
               }
               else
               {
                    m_OpMeshs.Add(_name, new List<AB_OpMesh>() { _op });
                    m_OpMeshsState.Add(_name, true);
               }
          }
          public void fn_HideOrShow(string _name, bool _state)
          {
               fnp_OpShow(_name, _state);
               //Thread t_th = new Thread((_name, _state) => { fnp_OpShow(_name, _state); });
          }

          protected void fnp_OpShow(string _name, bool _state)
          {
               if (m_OpMeshs.ContainsKey(_name) && (m_OpMeshsState[_name] != _state))
               {
                    List<AB_OpMesh> t_mesh = m_OpMeshs[_name];
                    for (int i = 0; i < t_mesh.Count; i++)
                    {
                         t_mesh[i].fn_hide(_state);
                    }
                    m_OpMeshsState[_name] = _state;
               }
          }
          private Transform m_player;

          public Transform Player
          {
               get { return m_player; }
               set {
                    Debug.Log("<color=red>set player</color>");
                    m_player = value;
                    
               
     
               if (m_check!=null)
               {
                    
                    Debug.Log("<color=blue>player</color>");
     
                    m_check.M_player = m_player; 
               }
               }
          }
          //检查物体距离玩家的检查类
          AB_OpCheck m_check = null;
          public AB_OpCheck M_OpCheck
          {
               set
               {
                    if (m_check==null)
                    {
                         m_check = value;
                         if (m_player!=null)
                         {
                              m_check.M_player = m_player;
                              m_check.fn_startCheck();
                         }
                         else
                         {
                              Invoke("fnp_findPlayer", 2f);
                         }
                         Debug.Log("<color=blue>player1</color>");
                    }
               }
               get { return m_check; }
          }
          protected void fnp_findPlayer()
          {
               
               Debug.Log("<color=red>找到玩家位置</color>");
     
               if (m_player != null)
               {
                    m_check.M_player = m_player;
                    m_check.fn_startCheck();
               }
               else
               {
                    Invoke("fnp_findPlayer", 1f);
               }
          }
          public void fn_end()
          {
               if (m_check!=null)
               {
                    m_check.fn_endCheck();
               }
          }
          /// <summary>
          /// 在玩家跳转的时候需要提前调用这个方法来显示到达位置的显示情况
          /// </summary>
          /// <param name="_playerWorldPos"></param>
          public void fn_SetImmediately(Vector3 _playerWorldPos)
          {
               if (m_check!=null)
               {
                    m_check.fn_SetImmediately(_playerWorldPos);
               }
          }
     
     
     }
}
