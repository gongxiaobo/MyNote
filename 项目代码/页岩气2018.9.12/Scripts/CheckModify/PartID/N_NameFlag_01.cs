using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 零件的编号
     /// </summary>
     public class N_NameFlag_01 : AB_NameFlag
     {

          public int m_nameid = 0;
          public override int M_nameID
          {
               get
               {
                    return m_nameid;
               }
               set
               {
                    m_nameid = value;
               }
          }

          public override E_YaobaType Me_Type
          {
               get
               {
                    throw new System.NotImplementedException();
               }
               set
               {
                    throw new System.NotImplementedException();
               }
          }
     } 
}
