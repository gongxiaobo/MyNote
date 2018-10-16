using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 为处理离开机器零件的高亮
     /// </summary>
     public class N_LightOneObj_01 : AB_LightOneObj
     {

          protected override void Start()
          {
               base.Start();
               fnp_findPartLight();
          }
          public override void fn_light()
          {
               //当机器里没有零件，需要高亮，这时就高亮零件
               if (m_partLight!=null)
               {
                    m_partLight.fn_light();
               }

          }

          public override void fn_endLigth()
          {
               //当机器中有零件，需要停止高亮，这时零件高亮关闭
               if (m_partLight != null)
               {
                    m_partLight.fn_endLigth();
               }
          }
          [SerializeField]
          /// <summary>
          /// 零件的高亮
          /// </summary>
          protected AB_LightOneObj m_partLight = null;
          protected void fnp_findPartLight()
          {
               AB_ThePart t_thePart = GetComponentInChildren<AB_ThePart>();
               if (t_thePart != null)
               {
                    m_partLight =
                         t_thePart.gameObject.GetComponentInChildren<AB_LightOneObj>(true);
                    //if (m_partLight==null)
                    //{

                    //     Debug.Log("<color=red>not find m_partLight!</color>");
     
                    //}
               }
               //else
               //{
                    
               //     Debug.Log("<color=red>not find AB_ThePart!</color>");
     
               //}
          }
     } 
}
