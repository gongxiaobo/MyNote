using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 通过形状，沿着指定路径，生成模型数据
/// </summary>
public class CreatePipe : MonoBehaviour {

    
     public void fn_Extrude(Mesh _mesh, ExtrudeShape _shape, OrientedPoint[] _path)
     {
          //切面的点数量
          int t_vertsInShape = _shape.m_verts.Length;
          //区域切分
          int t_segments = _path.Length - 1;
          int t_edgeLoops = _path.Length;
          //生成模型上的所有点
          int t_vertcount = t_vertsInShape * t_edgeLoops;
          //三角面数量
          int t_triCount = _shape.m_lines.Length * t_segments;
          //装载三角面的点
          int t_triIndexCount = t_triCount * 3;

          int[] t_triangleIndices = new int[t_triIndexCount];
          Vector3[] t_vertices = new Vector3[t_vertcount];
          Vector3[] t_normals = new Vector3[t_vertcount];
          Vector2[] t_uvs = new Vector2[t_vertcount];

          for (int i = 0; i < _path.Length; i++)
          {
               int t_offset = i * t_vertsInShape;
               for (int j = 0; j < t_vertsInShape; j++)
               {
                    int id = t_offset + j;
                    t_vertices[id] = _path[i].fn_localToWorld(_shape.m_verts[j]);
                    t_normals[id] = _path[i].fn_LocalToWorldDirection(_shape.m_normals[j]);
                    t_uvs[id] = new Vector2(_shape.m_us[j], i / ((float)t_edgeLoops));
               }
          }

          int ti = 0;
          for (int i = 0; i < t_segments; i++)
          {
               int offset = i * t_vertsInShape;
               for (int l = 0; l < _shape.m_lines.Length; l+=2)
               {//为三角面的点找到顶点集合中的编号
                    int a = offset + _shape.m_lines[l] + t_vertsInShape;
                    int b = offset + _shape.m_lines[l];
                    int c = offset + _shape.m_lines[l + 1];
                    int d = offset + _shape.m_lines[l + 1] + t_vertsInShape;
                    t_triangleIndices[ti] = a; ti++;
                    t_triangleIndices[ti] = b; ti++;
                    t_triangleIndices[ti] = c; ti++;
                    t_triangleIndices[ti] = c; ti++;
                    t_triangleIndices[ti] = d; ti++;
                    t_triangleIndices[ti] = a; ti++;

               }
          }
          //重新赋值给传入的mesh
          _mesh.Clear();
          _mesh.vertices = t_vertices;
          _mesh.triangles = t_triangleIndices;
          _mesh.normals = t_normals;
          _mesh.uv = t_uvs;
          

     }

}
