using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 按钮的高亮 基于imagecolor
     /// </summary>
     public class N_ropeLight : AB_ropeLight
     {

          public Color m_lightColor;
          protected Image m_image = null;
          protected Color m_default;
          protected override void Start()
          {
               base.Start();
               if (m_image == null)
               {
                    m_image = GetComponent<Image>();
               }
               if (m_image != null)
               {
                    m_default = m_image.color;
               }
          }
          public override void fn_highlight()
          {
               if (m_image!=null)
               {
                    m_image.color = m_lightColor;
               }
          }

          public override void fn_default()
          {
               if (m_image != null)
               {
                    m_image.color = m_default;
               }
          }
     } 
}
