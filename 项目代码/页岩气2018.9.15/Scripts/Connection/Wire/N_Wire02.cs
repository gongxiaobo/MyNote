using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 动态生成线后的线控制,需要在链接的时候动态生成线的模型，然后设置材质，粗细，meshcollider
     /// </summary>
     public class N_Wire02 : N_Wire
     {
          protected override void Start()
          {
               base.Start();
               //fnp_find();

          }
          public override void fn_init(string _para)
          {
               base.fn_init(_para);
               fnp_find();
          }
          AB_WireMat m_wireMat = null;
          string m_para;
          //AB_WireScale m_wireScale = null;
          public override void fn_init(string _para, AB_HandleEvent[] _ports)
          {
               base.fn_init(_para, _ports);
               m_para=_para;
               fnp_find();
               //生成电线模型
               fnp_birthPipe(_para);
              

          }
          private void fnp_find()
          {
               //if (m_meshrender == null)
               //{
                    m_meshrender = GetComponent<MeshRenderer>();
               //}

               m_meshCollider = GetComponent<MeshCollider>();
               //if (m_wireMat == null)
               //{
                    m_wireMat = GetComponent<AB_WireMat>();
               //}
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
          /// <summary>
          /// 根据新的参数，生成管线mesh
          /// </summary>
          /// <param name="_para"></param>
          protected virtual void fnp_birthPipe(string _para)
          {
               //选择的线的半径
               string _size = S_ParseWirePara.fn_getParaOne(_para, 2);
               float t_para = float.Parse(_size);
               AB_BirthMesh t_bm = S_BirthMeshs.Instance.fn_get(this.gameObject.name);
               if (t_bm!=null)
               {
                    t_bm.M_WireRadius = t_para/1000f;
                    t_bm.fn_BirthMesh(fnp_finishedBirthMesh);
                    
               }
          }
          //等待电线模型创建后，更换材质
          protected virtual void fnp_finishedBirthMesh()
          {
               //模型生成完成后，添加组件
               fnp_addComponent();
               if (m_wireMat != null)
               {//线的颜色变化
                    m_wireMat.fn_setMaterial(S_ParseWirePara.fn_getParaOne(m_para, 4));
               }
          }
          bool m_addcomponent = false;
          //添加高亮，和手柄交互的触发器
          protected void fnp_addComponent()
          {
               if (m_addcomponent)
               {
                    return;
               }
               m_addcomponent = true;
               gameObject.layer = 8;
               m_wireMat=gameObject.AddComponent<N_WireMat>();
              
               gameObject.AddComponent<WireLightTrigger02>();
               
               
          }

     }
}
