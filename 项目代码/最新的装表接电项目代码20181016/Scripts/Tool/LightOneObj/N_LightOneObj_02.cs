using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的高亮模式调整
     /// </summary>
     public class N_LightOneObj_02 : AB_LightOneObj, I_lightChangeMat
     {
          
         
          [EnumLabel("高亮的颜色")]
          public E_lightObjColor m_color = E_lightObjColor.e_green;
          [SerializeField]
          /// <summary>
          /// 当前高亮颜色
          /// </summary>
          protected E_lightObjColor m_currentcolor = E_lightObjColor.e_green;
          public MaterialObj m_materials;
          protected Material m_theDefault = null;
          public bool m_lightStart = false;
          protected override void Start()
          {
               base.Start();
               fnp_find();
          }
          [SerializeField]
          protected Material m_light;
          protected MeshRenderer m_mr;
          protected virtual void fnp_find()
          {
               MeshRenderer t_mr = GetComponent<MeshRenderer>();
               if (t_mr != null)
               {
                    fni_changeColor(m_color);
                    m_mr = t_mr;
                    if (m_theDefault==null)
                    {
                         m_theDefault = m_mr.material;
                    }
                    m_mr.material = m_light;
                    m_mr.enabled = m_lightStart;
               }
               else { Destroy(this); }
          }
          protected bool m_isLight = false;
          public override void fn_light()
          {
               if (m_mr == null)
               {

                    Debug.Log("<color=red>lightobj mesh =null ,</color>" + this.gameObject.name);

                    return;
               }
               if (m_mr.material != m_light)
               {
                    m_mr.material = m_light;
               }
               if (m_isLight)
               {
                    return;
               }
               
                    m_mr.enabled = true;

                    m_mr.material = m_light;
               

               m_isLight = true;
          }

          public override void fn_endLigth()
          {
               if (m_isLight == false)
               {
                    return;
               }
               //fni_changeColor(m_color);

               m_mr.enabled = false;
               
               m_isLight = false;
          }
         

          public void fni_changeColor(E_lightObjColor _color)
          {
               switch (_color)
               {
                    case E_lightObjColor.e_green:
                         m_light = m_materials.fn_get("green");
                         break;
                    case E_lightObjColor.e_red:
                         m_light = m_materials.fn_get("red");
                         break;
                    case E_lightObjColor.e_blue:
                         m_light = m_materials.fn_get("blue");
                         break;
                    case E_lightObjColor.e_yellow:
                         m_light = m_materials.fn_get("yellow");
                          break;
                    default:
                          m_light = m_materials.fn_get("green");
                          m_currentcolor = E_lightObjColor.e_green;
                          break;
               }
               m_currentcolor = _color;
               //m_mr.material = m_light;
          }



          public E_lightObjColor fni_getColorNow()
          {
               return m_currentcolor;
          }
     }
}
