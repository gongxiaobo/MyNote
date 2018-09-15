using System;
using System.Collections.Generic;
using Assets.Scripts.Bezier.BirthMesh.MyInterface;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Connection.SelectUI.RopePara;
namespace Assets.Scripts.Bezier.BirthMesh
{
     /// <summary>
     /// 管道生成工厂类
     /// 和父类相比，模型生成附加物体不由此类生成
     /// 加入设置线粗细和颜色的接口
     /// </summary>
     public class N_BirthMeshUsePoint01 : N_BirthMeshUsePoint, I_PutSizeAndColor
     {
          public override void fn_init()
          {
               //base.fn_init();
               if (m_meshobj != null)
               {
                   
              
                    MeshCollider t_mc = m_meshobj.GetComponent<MeshCollider>();
                    if (t_mc != null)
                    {
                         DestroyImmediate(t_mc);
                    }

                    if (m_meshobj.GetComponent<MeshFilter>()==null)
                    {//没有模型组件就添加
                         MeshFilter t_meshfilter = m_meshobj.AddComponent<MeshFilter>();
                         Mesh t_mesh = new Mesh();
                         t_meshfilter.mesh = t_mesh;
                         MeshRenderer t_render= m_meshobj.AddComponent<MeshRenderer>();
                         t_render.material = m_colorNow;
                         m_meshobj.AddComponent<N_LightOneObj_04>(); 
                    }
                    m_meshobj.transform.position = Vector3.zero;
               }
              
               
              
          }




          #region I_PutSizeAndColor
          Material m_colorNow = null;
          public void fni_PutSizeColor(float _size, Material _color)
          {
               float t_r = _size;
               t_r = t_r >= RopeParaSetting.m_RopeSize.y ? RopeParaSetting.m_RopeSize.y : t_r;
               t_r = t_r <= RopeParaSetting.m_RopeSize.x ? RopeParaSetting.m_RopeSize.x : t_r;
               m_wireR = t_r;
               m_colorNow = _color;

          } 
          #endregion
     }
}
