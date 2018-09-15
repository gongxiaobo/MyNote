using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 电线的基础功能
     /// </summary>
     public class N_Wire01 : N_Wire
     {
          protected override void Start()
          {
               base.Start();
               fnp_find();

          }
          public override void fn_init(string _para)
          {
               base.fn_init(_para);
               fnp_find();
          }
          AB_WireMat m_wireMat = null;
          //AB_WireScale m_wireScale = null;
          public override void fn_init(string _para, AB_HandleEvent[] _ports)
          {
               base.fn_init(_para, _ports);
               fnp_find();
               if (m_wireMat != null)
               {//线的颜色变化
                    m_wireMat.fn_setMaterial(S_ParseWirePara.fn_getParaOne(_para, 4));
               }
               //if (m_wireScale!=null)
               //{
               //     m_wireScale.fn_setWireSize(S_ParseWirePara.fn_getParaOne(_para, 2));
               //}
               
          }
          private void fnp_find()
          {
               if (m_meshrender == null)
               {
                    m_meshrender = GetComponent<MeshRenderer>();
               }
               if (m_meshCollider == null)
               {
                    m_meshCollider = GetComponent<MeshCollider>();
               }
               if (m_wireMat == null)
               {
                    m_wireMat = GetComponent<AB_WireMat>();
               }
               //if (m_wireScale == null)
               //{
               //     m_wireScale = GetComponent<AB_WireScale>();
               //}
          }
          public override void fn_show()
          {
               base.fn_show();
               fnp_find();
               if (m_meshrender != null)
               {
                    m_meshrender.enabled = true;
               }
               if (m_meshCollider != null)
               {
                    m_meshCollider.enabled = true;
               }
          }
          MeshRenderer m_meshrender = null;
          MeshCollider m_meshCollider = null;
          public override void fn_hide()
          {
               base.fn_hide();
               fnp_find();
               if (m_meshrender != null)
               {
                    m_meshrender.enabled = false;
               }
               if (m_meshCollider != null)
               {
                    m_meshCollider.enabled = false;
               }
          }

     } 
}
