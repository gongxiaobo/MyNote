using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.Multiply
{
     /// <summary>
     /// 注册一个接口多个连法
     /// </summary>
     public class N_MultiplyItemName : MonoBehaviour
     {
          void Start()
          {
               Transform[] t_childs = transform.GetComponentsInChildren<Transform>();
               string t_thisname = this.gameObject.name;
               if (t_childs.Length>1)
               {
                    List<string> t_other = new List<string>();
                    for (int i = 0; i < t_childs.Length; i++)
                    {
                         if (t_thisname==t_childs[i].name)
                         {
                              continue;
                         }
                         t_other.Add(t_childs[i].name);
                    }
                    //
                    //注册
                    S_MultiplyItem.Instance.fn_login(t_thisname, t_other.ToArray());

               }
               Destroy(this);
          }
          //string[] m_connects = null;
          //public string[] fn_getConnect()
          //{

          //     return null;
          //}

     }
}
