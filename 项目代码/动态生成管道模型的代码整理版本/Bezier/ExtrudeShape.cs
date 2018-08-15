using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrudeShape  {

     public Vector3[] m_verts;
     public Vector3[] m_normals;
     public float[] m_us;
     public int[] m_lines;
     public void fn_clear()
     {
          if (m_verts!=null)
          {
               m_verts = null;
          }
          if (m_normals!=null)
          {
               m_normals = null;
          }
          if (m_us!=null)
          {
               m_us = null;
          }
          if (m_lines!=null)
          {
               m_lines = null;
          }
     }
}
