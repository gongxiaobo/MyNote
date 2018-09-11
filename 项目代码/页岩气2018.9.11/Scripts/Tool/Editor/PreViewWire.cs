using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using UnityEngine.SceneManagement;
/// <summary>
/// 电线预览模式开启
/// </summary>
public class PreViewWire : EditorWindow
{
     [MenuItem("MyTool/PreViewWire")]
     static void init()
     {
          Rect wr = new Rect(0, 0, 200, 200);
          PreViewWire window = (PreViewWire)EditorWindow.GetWindowWithRect(typeof(PreViewWire),
               wr, true, "PreViewWire Tool V1.0");
          window.Show();


     }
     void OnGUI()
     {
          GUI.backgroundColor = Color.yellow;
          //GUI.skin.settings.selectionColor = Color.red;
          //GUI.skin.settings.cursorColor = Color.green;
          if (GUILayout.Button("预览生成线"))
          {

               fnp_previewwire();
          }
          if (GUILayout.Button("清除预览线"))
          {

               fnp_hidepreviewwire();
          }
        

     }
     void Update()
     {

          //Debug.Log("<color=blue>editor update</color>");
          if (m_preViews.Count>0)
          {
               for (int j = 0; j < m_preViews.Count; j++)
               {
                    m_preViews[j].fn_refresh();
               } 
          }
     }
     List<AB_BirthMesh> m_preViews = new List<AB_BirthMesh>();
     protected void fnp_previewwire()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    GameObject t_select = Selection.gameObjects[i];
                    AB_BirthMesh t_bm = t_select.GetComponent<AB_BirthMesh>();
                    if (t_bm != null)
                    {//test_startMesh
                         for (int j = 0; j < m_preViews.Count; j++)
                         {
                              if (t_bm == m_preViews[j])
                              {
                                   t_bm.fn_refresh();
                                   break;
                              }
                              if (j == m_preViews.Count - 1)
                              {
                                   fnp_view(t_select, t_bm);
                              }
                         }
                         if (m_preViews.Count == 0)
                         {
                              fnp_view(t_select, t_bm);
                         }
                    }

               }

          }
     }

     private void fnp_view(GameObject t_select, AB_BirthMesh t_bm)
     {
          test_startMesh t_test = t_select.GetComponent<test_startMesh>();
          if (t_test != null)
          {
               t_bm.fn_BirthMesh(t_test.fnp_callback);
          }
          else { t_bm.fn_BirthMesh(null); }

          m_preViews.Add(t_bm);
     }
     protected void fnp_hidepreviewwire()
     {
          for (int j = 0; j < m_preViews.Count; j++)
          {
               m_preViews[j].fn_kill();
          }
          m_preViews.Clear();
     }

    

}
