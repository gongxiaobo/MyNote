using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Bezier.BirthMesh.MyInterface;
namespace Assets.Scripts.Bezier.BirthMesh
{
     /// <summary>
     /// 通过这个单例类来生成管道模型，
     /// 保存模型实例，生成，删除管道模型
     /// </summary>
     public class S_BirthPipeMesh : GenericSingletonClass<S_BirthPipeMesh>
     {
          /// <summary>
          /// 所有生成的管道模型
          /// </summary>
          Dictionary<string, GameObject> m_Pipes = new Dictionary<string, GameObject>();
          I_PutKeyPoint mi_putPoint = null;
          I_PutSizeAndColor mi_putSizeColor = null;
          AB_BirthMesh m_birthMesh = null;
          public void fn_BirthPipe(string _pipename, Vector3[] _keyPoints, float _size, Material _wiremat,Vector3 _meshUpDir)
          {
               if (_keyPoints==null)
               {
                    return;
               }
               if (m_birthMesh==null)
               {
                    m_birthMesh = gameObject.AddComponent<N_BirthMeshUsePoint01>();
                    //m_birthMesh.m_AddMorKeyPoits = false;
                   
               }
               if (mi_putPoint == null)
               {
                    mi_putPoint = GetComponent<I_PutKeyPoint>();
               }
               if (mi_putSizeColor==null)
               {
                    mi_putSizeColor = GetComponent<I_PutSizeAndColor>();

               }

               if (!m_Pipes.ContainsKey(_pipename))
               {//还没有生成管道
                    m_Pipes.Add(_pipename, new GameObject(_pipename));
                   
               }
               m_birthMesh.m_MeshUpDir = _meshUpDir;
               m_birthMesh.M_MeshObj = m_Pipes[_pipename];
               mi_putSizeColor.fni_PutSizeColor(_size, _wiremat);
               mi_putPoint.fni_putKeyPoint(_keyPoints);
               m_birthMesh.fn_BirthMesh(() =>
               {
                    Debug.Log("<color=blue>birth pipe complete : </color>" + _pipename);
               });

          }


     }
}
