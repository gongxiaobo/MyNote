using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的步骤数据表
     /// </summary>
     public class S_TableStepInfo : GenericSingletonClass<S_TableStepInfo>
     {
          /// <summary>
          /// 步骤数据表
          /// </summary>
          Dictionary<string, subject_step> m_tableDate = null;
          /// <summary>
          /// 步骤数据表
          /// </summary>
          public Dictionary<string, subject_step> M_tableDate
          {
               get { return m_tableDate; }
               set
               {
                    if (m_tableDate==null)
                    {
                         m_tableDate = value;  
                    }
               }
          }


               

                       
         
     } 
}
