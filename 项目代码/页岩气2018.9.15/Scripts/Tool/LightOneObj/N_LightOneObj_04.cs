using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电模式下，运行时生成电线的高亮控制类
     /// </summary>
     public class N_LightOneObj_04 : N_LightOneObj, I_SetWireMat
     {
          protected override void Start()
          {
               base.Start();

               //AB_Wire t_wire = GetComponent<AB_Wire>();
               //if (t_wire != null)
               //{
               //     t_wire.fn_hide();
               //}
          }
          public override void fn_light()
          {
               if (m_mr == null)
               {

                    Debug.Log("<color=red>lightobj mesh =null ,</color>" + this.gameObject.name);

                    return;
               }
               if (m_isLight)
               {
                    return;
               }
               //if (m_isTrigger)
               //{
               m_mr.enabled = true;
               m_mr.material = m_light;
               //}
               //else
               //{
               //     m_mr.material = m_light != null ? m_light : m_default;
               //}

               m_isLight = true;
          }

          public override void fn_endLigth()
          {
               if (m_isLight == false)
               {
                    return;
               }
               m_mr.material = m_default;
               //if (m_isTrigger)
               //{
               //m_mr.enabled = false;
               //}
               //else
               //{

               //}
               m_isLight = false;
          }


          public void fni_setWireDefaultMat(Material _newMat)
          {
               m_default = _newMat;
               m_mr.material = m_default;
          }
         
     } 
}
