using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_LightOneObj : AB_LightOneObj
     {
          public bool m_isTrigger = false;
          string m_materialname = "LightObj";
          [EnumLabel("高亮的颜色")]
          public E_lightObjColor m_color = E_lightObjColor.e_green;
          public bool m_lightStart = true;
          protected override void Start()
          {
               base.Start();
               fnp_find();
               //if (m_lightStart)
               //{
               //     fn_light(); 
               //}
          }
          protected Material m_light, m_default;
          protected MeshRenderer m_mr;
          protected virtual void fnp_find()
          {
               MeshRenderer t_mr = GetComponent<MeshRenderer>();
               if (t_mr != null)
               {
                    m_materialname = fnp_getName(m_color);
                    m_mr = t_mr;
                    m_default = m_mr.material;
                    Object t_matrial = Resources.Load("Material/" + m_materialname);
                    m_light = (t_matrial != null) ? Instantiate(t_matrial as Material) : null;
                    if (m_isTrigger)
                    {
                         m_mr.material = m_light;
                         t_mr.enabled = false;
                         //gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f); 
                    }
               }
               else { Destroy(this); }
          }
          protected bool m_isLight = false;
          public override void fn_light()
          {
               if (m_isLight)
               {
                    return;
               }
               if (m_isTrigger)
               {
                    m_mr.enabled = true;
                    m_mr.material = m_light;
               }
               else
               {
                    m_mr.material = m_light != null ? m_light : m_default;
               }

               m_isLight = true;
          }

          public override void fn_endLigth()
          {
               if (m_isLight == false)
               {
                    return;
               }

               if (m_isTrigger)
               {
                    m_mr.enabled = false;
               }
               else
               {
                    m_mr.material = m_default;
               }
               m_isLight = false;
          }
          protected string fnp_getName(E_lightObjColor _color)
          {
               switch (_color)
               {
                    case E_lightObjColor.e_green:
                         return "LightObj";
                    case E_lightObjColor.e_red:
                         return "LightObj_red";
                    case E_lightObjColor.e_blue:
                         return "LightObj_blue";
                    case E_lightObjColor.e_yellow:
                         return "LightObj_yellow";
                    default:
                         return "LightObj";
               }
          }
     }
     public enum E_lightObjColor
     {
          [EnumLabel("绿")]
          e_green = 1,
          [EnumLabel("红")]
          e_red = 2,
          [EnumLabel("蓝")]
          e_blue = 3,
          [EnumLabel("黄")]
          e_yellow = 4,
     }

}