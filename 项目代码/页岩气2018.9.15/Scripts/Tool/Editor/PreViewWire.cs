using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GasPowerGeneration;
//using UnityEngine.SceneManagement;
/// <summary>
/// 电线预览模式开启
/// </summary>
public class PreViewWire : EditorWindow
{
     [MenuItem("MyTool/PreViewWire")]
     static void init()
     {
          Rect wr = new Rect(0, 0, 200, 250);
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
          if (GUILayout.Button("接口位置物体"))
          {

               fnp_createPortPosObj();
          }
          if (GUILayout.Button("接口位置物体局部坐标归零"))
          {

               fnp_ResetPortPosObj();
          }
          if (GUILayout.Button("选中接口位置物体"))
          {

               fnp_selectPortObj();
          }
          GUILayout.Label("name select", EditorStyles.boldLabel);
          m_startID = EditorGUILayout.FloatField("startID ", m_startID);
          //m_endID = EditorGUILayout.FloatField("endID ", m_endID);
          if (GUILayout.Button("多个接口的命名"))
          {

               fnp_setNameUseObjsName();
          }
          if (GUILayout.Button("单个接口的命名"))
          {

               fnp_setNameUseObjName();
          }
          if (GUILayout.Button("检查接口名称匹配"))
          {

               fnp_checkName();
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
     protected void fnp_checkName()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    
                    AB_Name t_name = Selection.gameObjects[i].GetComponent<AB_Name>();
                    if (t_name != null)
                    {
                         if (Selection.gameObjects[i].name!=(t_name.m_ID.ToString()))
                         {

                              Debug.Log("<color=red>名称不匹配：</color>" + Selection.gameObjects[i].name);

                         }
                         else
                         {

                              Debug.Log("<color=blue>名称匹配:</color>" + Selection.gameObjects[i].name);
     
                         }
                    }
               }
          }
     }
     protected float m_startID;
     protected void fnp_setNameUseObjsName()
     {
          //float t_start = m_startID;
          //float t_end = m_endID;
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    Selection.gameObjects[i].name = m_startID.ToString();
                    AB_Name t_name = Selection.gameObjects[i].GetComponent<AB_Name>();
                    if (t_name != null)
                    {
                         t_name.m_ID = (int)m_startID;
                    }
                    m_startID++;

               }
              

          }
     }
     protected void fnp_setNameUseObjName()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0 || Selection.gameObjects.Length>1)
               {
                    return;
               }
               AB_Name t_name = Selection.gameObjects[0].GetComponent<AB_Name>();
               if (t_name!=null)
               {
                    t_name.m_ID = int.Parse(Selection.gameObjects[0].name);
               }
              
          }
     }
     /// <summary>
     /// 为接口添加位置子节点
     /// </summary>
     protected void fnp_createPortPosObj()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               for (int i = 0; i < Selection.gameObjects.Length; i++) {
                    if (Selection.gameObjects[i].transform.Find("port")==null)
                    {
                         GameObject t_new = new GameObject("port");
                         t_new.transform.parent = Selection.gameObjects[i].transform;
                         t_new.transform.localPosition = Vector3.zero;
                    }
               
               
               }
          }
     }
     protected void fnp_ResetPortPosObj()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    Transform t_port=Selection.gameObjects[i].transform.Find("port");
                    if (t_port != null)
                    {
                         t_port.localPosition = Vector3.zero;
                    }


               }
          }
     }
     void fnp_selectPortObj()
     {
          List<GameObject> t_objects = new List<GameObject>();
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    Transform t_port = Selection.gameObjects[i].transform.Find("port");
                    if (t_port != null)
                    {
                         t_objects.Add(t_port.gameObject);
                    }


               }
          }
          if (t_objects.Count>0)
          {
               fns_select(t_objects.ToArray()); 
          }
     }
     //选中指定的物体
     void fns_select(GameObject[] _select)
     {
          if (_select != null)
          {
               if (_select.Length == 0)
               {
                    return;
               }
               Selection.objects = _select;
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
