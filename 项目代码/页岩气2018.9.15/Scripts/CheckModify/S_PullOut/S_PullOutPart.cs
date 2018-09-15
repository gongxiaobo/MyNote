using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 可以以拉出的零件的集合
     /// </summary>
     public class S_PullOutPart : GenericSingletonClass<S_PullOutPart>
     {
          protected Dictionary<int, AB_PullOut> m_PullOut = new Dictionary<int, AB_PullOut>();
          public int m_count = 0;
          public void fn_login(int _id, AB_PullOut _pullout)
          {
               if (!m_PullOut.ContainsKey(_id) && _pullout!=null)
               {
                    m_PullOut.Add(_id, _pullout);
                    m_count++;
               }
               else
               {
                    Debug.Log("<color=red>m_PullOut.ContainsKey(_id) || _pullout==null</color>");
     
               }
          }
          public AB_PullOut fn_getPullOut(int _id)
          {
               if (m_PullOut.ContainsKey(_id))
               {
                    return m_PullOut[_id];
               }
               return null;
          }
         
     } 
}
