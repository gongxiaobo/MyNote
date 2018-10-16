using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 放入， 获取矩形信息
     /// </summary>
     public class N_Rectangle : AB_Rectangle
     {
          Vector3[] m_rectangle;
          public override void fn_putIn4Point(Vector3[] _rec)
          {
               if (_rec==null)
               {
                    return;
               }
               if (_rec.Length!=4)
               {
                    
                    Debug.Log("<color=red>Rectangle has more than 4 vertics!</color>");
     
                    return;
               }
               m_rectangle = _rec;
          }

          public override Vector3[] fn_get4Point()
          {
               if (m_rectangle!=null)
               {
                    return m_rectangle;
               }
               return null;
          }
          Vector3[] m_key;
          public override void fn_putIn2Point(Vector3[] _key)
          {
               if (_key == null)
               {
                    return;
               }
               if (_key.Length != 2)
               {

                    Debug.Log("<color=red>m_key has more than 2 vertics!</color>");

                    return;
               }
               m_key = _key;
          }

          public override Vector3[] fn_get2Point()
          {
               if (m_key != null)
               {
                    return m_key;
               }
               return null;
          }
     }
}
