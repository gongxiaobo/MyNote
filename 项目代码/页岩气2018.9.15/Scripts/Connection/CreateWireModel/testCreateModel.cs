using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCreateModel : MonoBehaviour {
     public float m_width = 1f;
     public float m_height = 1f;
     public Material m_mat = null;
	// Use this for initialization
	void Start () {
          MeshFilter t_meshfilter = gameObject.AddComponent<MeshFilter>();
          Mesh t_mesh = new Mesh();
          t_meshfilter.mesh = t_mesh;

          Vector3[] t_vertices = new Vector3[4];
          t_vertices[0] = new Vector3(1, 0, 1);
          t_vertices[1] = new Vector3(-1, 0, 1);
          t_vertices[2] = new Vector3(1, 0,-1);
          t_vertices[3] = new Vector3(-1, 0, -1);

          int[] t_triangles = new int[6];
          t_triangles[0] = 0;
          t_triangles[1] = 2;
          t_triangles[2] = 1;

          t_triangles[3] = 2;
          t_triangles[4] = 3;
          t_triangles[5] = 1;

          Vector3[] t_normal = new Vector3[4];
          t_normal[0] = new Vector3(0,1,0);
          t_normal[1] = new Vector3(0, 1, 0);
          t_normal[2] = new Vector3(0, 1, 0);
          t_normal[3] = new Vector3(0,1,0);

          Vector2[] t_uv = new Vector2[4];
          t_uv[0] = new Vector2(0f, 0f);
          t_uv[1] = new Vector2(1f, 0f);
          t_uv[2] = new Vector2(0f, 1f);
          t_uv[3] = new Vector2(1f, 1f);

          t_mesh.vertices = t_vertices;
          t_mesh.triangles = t_triangles;
          t_mesh.normals = t_normal;
          t_mesh.uv = t_uv;
          MeshRenderer t_mr = gameObject.AddComponent<MeshRenderer>();
          t_mr.material = m_mat;
          gameObject.AddComponent<MeshCollider>();
	}

     Vector3 GetPoint(Vector3[] pts, float t)
     {
          Vector3 a = Vector3.Lerp(pts[0], pts[1], t);
          Vector3 b = Vector3.Lerp(pts[1], pts[2], t);
          Vector3 c = Vector3.Lerp(pts[2], pts[3], t);
          Vector3 d = Vector3.Lerp(a, b, t);
          Vector3 e = Vector3.Lerp(b, c, t);
          return Vector3.Lerp(d, e, t);

     }
	// Update is called once per frame
     //void Update () {
		
     //}
}
