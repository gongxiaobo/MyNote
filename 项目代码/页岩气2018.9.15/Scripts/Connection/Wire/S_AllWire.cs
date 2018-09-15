using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 所有电线的集合
     /// </summary>
     public class S_AllWire : GenericSingletonClass<S_AllWire>
     {
          protected Dictionary<string, AB_Wire> m_allWires = new Dictionary<string, AB_Wire>();
          public void fn_putIn(string _wireName, AB_Wire _wire)
          {
               if (!m_allWires.ContainsKey(_wireName))
               {
                    m_allWires.Add(_wireName, _wire);
               }
               else
               {
                    Debug.Log("<color=red>same wire name!</color>" + _wireName);
               }

          }
          public AB_Wire fn_getWire(string _name)
          {
               if (m_allWires.ContainsKey(_name))
               {
                    return m_allWires[_name];
               }
               return null;
          }
          /// <summary>
          /// 电线的初始化和显示
          /// </summary>
          /// <param name="_wireName">线的名称</param>
          /// <param name="_init">初始化参数</param>
          public void fn_ShowWire(string _wireName,string _init)
          {
               AB_Wire t_wire = fn_getWire(_wireName);
               if (t_wire!=null)
               {
                    t_wire.fn_init(_init);
                    t_wire.fn_show();
               }
          }


     } 
}
