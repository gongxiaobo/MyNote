using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 零件初始化拿出后放置在地面上的位置信息
     /// </summary>
     public class S_PartOnGround : GenericSingletonClass<S_PartOnGround>
     {
          Dictionary<string, Transform> m_onGround = new Dictionary<string, Transform>();
          void Start()
          {
               fnp_findPos();
          }
          public Vector3 fn_getPos(int _id)
          {
               fnp_findPos();
               if (m_onGround.ContainsKey(_id.ToString()))
               {
                    return m_onGround[_id.ToString()].position;
               }
               else
               {
                    
                    Debug.Log("<color=red>not find pos of </color>"+_id);
     
               }
               return Vector3.one;
          }
          bool m_find = false;
          private void fnp_findPos()
          {
               if (m_find)
               {
                    return;
               }
               m_find = true;
               if (m_onGround.Count == 0)
               {
                    Transform[] t_ = GetComponentsInChildren<Transform>();
                    for (int i = 0; i < t_.Length; i++)
                    {
                         if (t_[i].name=="Cube")
                         {
                              continue;
                         }
                         if (m_onGround.ContainsKey(t_[i].name))
                         {

                              //Debug.Log("<color=red>出现相同的名称ID!</color>");

                              continue;
                         }
                         else
                         {
                              m_onGround.Add(t_[i].name, t_[i]);

                              //Debug.Log("<color=blue>blue:</color>" + t_[i].name);
     
                         }
                    }
               }
          }

          
     } 
}
