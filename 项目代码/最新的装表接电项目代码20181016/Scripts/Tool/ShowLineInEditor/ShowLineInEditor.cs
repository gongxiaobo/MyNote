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
          /// <summary>
          /// 一直显示线
          /// </summary>
          /// <param name="_name"></param>
          /// <param name="_points"></param>
          /// <param name="_color"></param>
          public void fn_PutInDot(string _name, Vector3[] _points,Color _color)
          {
               if (_points==null)
               {
                    return;
               }
              
               if (!m_showLines.ContainsKey(_name))
               {
                    m_addOrRemove = true;
                    m_showLines.Add(_name, new ShowData());
               }
               else
               {
                    fnp_showTemp(_points, _color);
                    return;
               }
              
               m_showLines[_name].m_points = _points;
               m_showLines[_name].m_color = _color;
               m_addOrRemove = false;
          }
          /// <summary>
          /// 临时短暂的显示
          /// </summary>
          /// <param name="_points"></param>
          /// <param name="_color"></param>
          /// <param name="_length"></param>
          public void fn_PutInDot(Vector3[] _points, Color _color, float _length = 2f)
          {
               fnp_showTemp(_points, _color, _length);
          }
          protected void fnp_showTemp(Vector3[] _points, Color _color,float _length=2f)
          {
               fnp_drawLine(_points, _color,true, _length);
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
               fnp_drawLine(item.m_points, item.m_color);
          }

          private void fnp_drawLine(Vector3[] _pos,Color _color,bool _showtemp=false,float _duration=2f)
          {
               if (_pos==null)
               {
                    return;
               }
               Vector3[] t_point = _pos;
               Color t_color = _color;
               for (int i = 0; i < t_point.Length; i++)
               {
                    if (m_addOrRemove)
                    {
                         break;
                    }
                    if (_showtemp==false)
                    {
                         Debug.DrawLine(t_point[i], t_point[(i + 1) == t_point.Length ? i : (i + 1)], t_color);
                    }
                    else
                    {
                         Debug.DrawLine(t_point[i], t_point[(i + 1) == t_point.Length ? i : (i + 1)], t_color,_duration);
                    }
               }
          }
     }
}
