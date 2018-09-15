using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 初始化时获取玩家位置
     /// </summary>
     public class N_GetPos : AB_GetPos
     {
          Dictionary<string, Vector3> m_pos = new Dictionary<string, Vector3>();
          protected override void Start()
          {
               base.Start();
               fnp_find();
               S_SceneMagT1.Instance.M_getPos = this;
          }
          protected void fnp_find()
          {
               Transform[] t_child = GetComponentsInChildren<Transform>();
               for (int i = 0; i < t_child.Length; i++)
               {
                    if (!m_pos.ContainsKey(t_child[i].name))
                    {
                         m_pos.Add(t_child[i].name, t_child[i].position);
                    }
               }
               t_child = null;
          }
          public override Vector3 fn_getPos(string _name)
          {
               if (m_pos.ContainsKey(_name))
               {
                    return m_pos[_name];
               }
               else if (m_pos.ContainsKey("default"))
               {
                    return m_pos["default"];
               }
               return new Vector3(0f, 0f, 0f);
          }
     }

}