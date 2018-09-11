using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Tool.ShowLineInEditor
{
     /// <summary>
     /// 在编辑器中指定显示的线路
     /// </summary>
     public class ShowLineInEditor : GenericSingletonClass<ShowLineInEditor>
     {
          Dictionary<string, ShowData> m_showLines = new Dictionary<string, ShowData>();
          public void fn_PutInDot(string _name, Vector3[] _points,Color _color)
          {
               if (_points==null)
               {
                    return;
               }
               m_addOrRemove = true;
               if (!m_showLines.ContainsKey(_name))
               {
                    m_showLines.Add(_name, new ShowData());
               }
              
               m_showLines[_name].m_points = _points;
               m_showLines[_name].m_color = _color;
               m_addOrRemove = false;
          }
          public void fnp_remove(string _name)
          {
               m_addOrRemove = true;
               if (m_showLines.ContainsKey(_name))
               {
                    m_showLines.Remove(_name);
               }
               m_addOrRemove = false;
          }
          bool m_addOrRemove = false;
          void Update()
          {
               foreach (ShowData item in m_showLines.Values)
               {
                    if (m_addOrRemove)
                    {
                         break;
                    }
                    fnp_showOneLine(item);
               }

          }

          private void fnp_showOneLine(ShowData item)
          {
               if (item==null)
               {
                    return;
               }
               if (m_addOrRemove)
               {
                    return;
               }
               Vector3[] t_point = item.m_points;
               Color t_color = item.m_color;
               for (int i = 0; i < t_point.Length; i++)
               {
                    if (m_addOrRemove)
                    {
                         break;
                    }
                    Debug.DrawLine(t_point[i], t_point[(i + 1) == t_point.Length ? 0 : (i + 1)], t_color);
               }
          }
     }
}
