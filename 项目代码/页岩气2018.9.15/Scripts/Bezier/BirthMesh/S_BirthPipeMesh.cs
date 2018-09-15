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
               if (m_Pipes.ContainsKey(_pipename))
               {
                    return;
               }
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
          /// <summary>
          /// 删除链接线
          /// </summary>
          /// <param name="_pipeName"></param>
          public void fn_removePipe(string _pipeName)
          {
               if (m_Pipes.ContainsKey(_pipeName))
               {
                    Destroy(m_Pipes[_pipeName]);
                    m_Pipes.Remove(_pipeName);
               }
          }
          /// <summary>
          /// 查看是否生成给定名称的电线，返回true为已经生成
          /// </summary>
          /// <param name="_pipename"></param>
          /// <returns></returns>
          public bool fn_checkPipeExit(string _pipename)
          {
               if (m_Pipes.ContainsKey(_pipename))
               {
                    return true;
               }
               return false;
          }
          /// <summary>
          /// 获取电线物体
          /// </summary>
          /// <param name="_pipeName"></param>
          /// <returns></returns>
          public GameObject fn_getPipeObj(string _pipeName)
          {
               if (m_Pipes.ContainsKey(_pipeName))
               {
                    return m_Pipes[_pipeName];
               }
               return null;
          }

     }
}
