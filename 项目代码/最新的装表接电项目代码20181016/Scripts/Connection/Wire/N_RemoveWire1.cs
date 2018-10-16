using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Bezier.BirthMesh;
using Assets.Scripts.Connection.PointOnPlane;
namespace Assets.Scripts.Connection.Wire
{
     class N_RemoveWire1 : AB_RemoveWire
     {
          AB_HandleEvent[] m_ports;
          string m_info;
          public override void fn_init(string _info, AB_HandleEvent[] _handleEvent)
          {
               m_ports = _handleEvent;
               m_info = _info;
          }

          public override void fn_remove()
          {
               AB_SetState t_setState = new N_SetState();

               for (int i = 0; i < m_ports.Length; i++)
               {
                    string[] t_split = S_ParseWirePara.fn_SplitToThree(m_ports[i].fn_getMainValue());
                    string t_new = "";
                    for (int j = 0; j < t_split.Length; j++)
                    {
                         if (t_split[j] != m_info && t_split[j] != "")
                         {
                              t_new += t_split[j];
                         }
                    }
                    t_setState.fn_setState("string", t_new, m_ports[i]);
               }
               //通知销毁电线模型
               S_BirthPipeMesh.Instance.fn_removePipe(this.gameObject.name);
               //告诉平面的排序，取消这个条线的排序
               S_Planes.Instance.fn_removeWire(this.gameObject.name);
          }
     }
}
