using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_NameFlag : AB_NameFlag
     {
          public int m_nameID = 0;
          public override int M_nameID
          {
               get
               {
                    return m_nameID;
               }
               set
               {
                    m_nameID = value;
               }
          }
          public E_YaobaType me_yaobaType = E_YaobaType.e_one;
          /// <summary>
          /// 摇把的类型
          /// </summary>
          public override E_YaobaType Me_Type
          {
               get
               {
                    return me_yaobaType;
               }
               set
               {
                    me_yaobaType = value;
               }
          }

     } 
}
