using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using GasPowerGeneration;
using Assets.Scripts.test.Optimization;
using UnityEngine.UI;
/// <summary>
/// 编辑器扩展，常用的操作
/// </summary>
public class MyEditorTool : EditorWindow{
     //string myString = "Hello World";
     //bool groupEnabled;
     //bool myBool = true;
     //float myFloat = 1.23f;
     [MenuItem("MyTool/MyEditorTool")]
     static void Apply()
     {
          Rect wr = new Rect(0, 0, 200, 800);
          MyEditorTool window = (MyEditorTool)EditorWindow.GetWindowWithRect(typeof(MyEditorTool),
               wr, true, "Tool V1.0");
          window.Show();
     }
     bool m_redmodify = true;
     void OnGUI()
     {
          GUI.backgroundColor = Color.green;
          if (m_redmodify)
          {
               m_redmodify = false;
               GUI.skin.settings.selectionColor = Color.red;
               GUI.skin.settings.cursorColor = Color.green;
          }
          #region make prefab
          GUILayout.Label("Make prefab", EditorStyles.boldLabel);
          m_folder = EditorGUILayout.TextField("Path:Assets/Resources/", m_folder);
          if (GUILayout.Button("生成预制"))
          {

               fns_makePrefab();
          } 
          #endregion

          #region scale copy and past pos
          GUILayout.Label("scale all", EditorStyles.boldLabel);
          m_scale = EditorGUILayout.FloatField("scale ", m_scale);
          if (GUILayout.Button("统一缩放"))
          {

               fnp_setScele();
          }


          GUILayout.Label("cope past pos", EditorStyles.boldLabel);
          m_pos = EditorGUILayout.Vector3Field("pos ", m_pos);
          //GUILayout.BeginHorizontal("box1");
          if (GUILayout.Button("copy world pos"))
          {

               fnp_copyPos();
          }
          if (GUILayout.Button("past world pos"))
          {

               fnp_pastPos();
          }
          //GUILayout.EndHorizontal();
          //GUILayout.BeginHorizontal("box2");
          if (GUILayout.Button("copy local pos"))
          {
               fnp_copylocalPos();
          }
          if (GUILayout.Button("past local pos"))
          {
               fnp_pastlocalPos();
          }
          //GUILayout.EndHorizontal();
          if (GUILayout.Button("原点位置"))
          {

               fnp_setorialPos();
          }
          if (GUILayout.Button("旋转归零"))
          {

               fnp_resetRotate();
          }
          //GUILayout.BeginHorizontal("box3");
          if (GUILayout.Button("copy name"))
          {

               fnp_copyName();
          }
          if (GUILayout.Button("past name"))
          {

               fnp_pasteName();
          }
          //GUILayout.EndHorizontal();
          if (GUILayout.Button("add parent"))
          {

               fns_addParent();
          } 
          #endregion

          #region Sort
          GUILayout.Label("sort", EditorStyles.boldLabel);
          m_sortOffset = EditorGUILayout.Vector3Field("sort", m_sortOffset);
          if (GUILayout.Button("select sort"))
          {

               fnp_SortObj();
          } 
          #endregion
          #region 加载条件反射
          if (GUILayout.Button("add NameState"))
          {

               fns_ConditionsAndResult();
          } 
          #endregion
          #region 移除机器上的名称编号和机器名称
          if (GUILayout.Button("remove nameID"))
          {

               fns_removeID();
          }
          #endregion
          #region 找到Item
          GUILayout.Label("Find item id obj", EditorStyles.boldLabel);
          m_ID = EditorGUILayout.IntField("item id", m_ID);
          if (GUILayout.Button("选中物体查找指定ID"))
          {

               fns_findItemID();
          }
          if (GUILayout.Button("全局查找指定的ID"))
          {

               fns_findItemIDNoSelect();
          }  
          #endregion
          if (GUILayout.Button("移除static 的AI"))
          {

               fns_removeAIstatic();
          }

          #region 添加优化物体类
          m_nameOfOp = EditorGUILayout.TextField("name", m_nameOfOp);
          if (GUILayout.Button("添加优化物体类"))
          {

               fns_addOptimiz();
          }
          if (GUILayout.Button("移除优化物体类"))
          {

               fnp_removeOptimiz();
          }
          if (GUILayout.Button("查看优化效果"))
          {

               fnp_showOptimiz();
          }  
          #endregion
          if (GUILayout.Button("装表接电的电线配置组件"))
          {

               fns_TableWireSet();
          }
          if (GUILayout.Button("装表接电的接口ID"))
          {

               fns_TableSetPortName();
          }

          GUILayout.Label("Set UI Scale", EditorStyles.boldLabel);
          if (GUILayout.Button("修改UI的尺寸"))
          {

               fnp_setUIScale();
          }
          //if (GUILayout.Button("记录摄像机位置"))
          //{

          //     fnp_thescene();
          //}
          //if (GUILayout.Button("上一次摄像机位置"))
          //{

          //     fnp_backView();
          //} 
          //GUILayout.Label("Base Settings", EditorStyles.boldLabel);
          //myString = EditorGUILayout.TextField("Text Field", myString);

          //groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
          //myBool = EditorGUILayout.Toggle("Toggle", myBool);
          //myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
          //EditorGUILayout.EndToggleGroup();


     }
     #region make prefab
     string m_path = "Assets/Resources/";
     string m_folder = "";
     //string m_className = "N_tree";
     void fns_makePrefab()
     {
          if (!Directory.Exists(m_path + m_folder))
          {
               Directory.CreateDirectory(m_path + m_folder);
          }
          if (Selection.activeGameObject != null)
          {

               foreach (GameObject g in Selection.gameObjects)
               {

                    //if (!Directory.Exists(m_path + m_folder))
                    //{
                    //     Directory.CreateDirectory(m_path + m_folder);
                    //}
                    Object t_prefab;
                    t_prefab = PrefabUtility.CreateEmptyPrefab(
                        m_path + m_folder + "/" + g.name + ".prefab");
                    t_prefab = PrefabUtility.ReplacePrefab(g, t_prefab);

               }

          }

     } 
     #endregion

     #region scale copy and past pos
     float m_scale = 1f;
     void fnp_setScele()
     {
          foreach (GameObject g in Selection.gameObjects)
          {

               g.transform.localScale = new Vector3(m_scale, m_scale, m_scale);

          }
     }
     Vector3 m_pos = new Vector3(0f, 0f, 0f);
     void fnp_copyPos()
     {
          if (Selection.gameObjects.Length == 1)
          {
               m_pos = Selection.gameObjects[0].transform.position;
          }
     }
     void fnp_copylocalPos()
     {
          if (Selection.gameObjects.Length == 1)
          {
               m_pos = Selection.gameObjects[0].transform.localPosition;
          }
     }
     void fnp_pastPos()
     {
          if (Selection.gameObjects.Length == 1)
          {
               Selection.gameObjects[0].transform.position = m_pos;
          }
     }
     void fnp_pastlocalPos()
     {
          if (Selection.gameObjects.Length == 1)
          {
               Selection.gameObjects[0].transform.localPosition = m_pos;
          }
     }
     void fnp_setorialPos()
     {
          m_pos = new Vector3(0f, 0f, 0f);
     }
     void fnp_resetRotate()
     {
          foreach (GameObject g in Selection.gameObjects)
          {

               g.transform.rotation = Quaternion.identity;

          }
     }
     #endregion
     string m_objname = "Noname";
     void fnp_copyName()
     {
          if (Selection.gameObjects.Length == 1)
          {
               m_objname = Selection.gameObjects[0].name;
          }
     }
     void fnp_pasteName()
     {
          if (Selection.gameObjects.Length == 1)
          {
               Selection.gameObjects[0].name = m_objname;
          }
     }

     /// <summary>
     /// 为选中物体添加一个单位化且名称相同的父节点
     /// </summary>
     void fns_addParent()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length > 1 || Selection.gameObjects.Length == 0)
               {
                    return;
               }
               GameObject t_select = Selection.gameObjects[0];
               //查找下，是否已经添加过
               int t_count = 0;
               foreach (var item in t_select.transform.GetComponentsInChildren<Transform>(true))
               {

                    if (item.name == t_select.name)
                    {
                         t_count++;
                         continue;
                    }

               }
               if (t_count >= 2)
               {
                    return;
               }



               GameObject t_newObj = new GameObject(t_select.name);
               t_newObj.transform.position = t_select.transform.position;
               t_newObj.transform.rotation = Quaternion.identity;
               t_select.transform.parent = t_newObj.transform;
               //			if (t_newObj.transform.position!=Vector3.zero) {
               //				t_newObj.transform.position = Vector3.zero;
               //			}
          }

     }
     Vector3 m_sortOffset = new Vector3(0.1f, 0f, 0f);
     void fnp_SortObj()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               Vector3 t_startPos = Vector3.zero;
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {

                    for (int j = 0; j < Selection.gameObjects.Length; j++)
                    {

                         if (Selection.gameObjects[j].name.EndsWith(i.ToString()))
                         {
                              if (i==0)
                              {
                                   t_startPos = Selection.gameObjects[j].transform.position;
                              }else{
                                   Selection.gameObjects[j].transform.position = t_startPos + i * m_sortOffset;
                              }
                              
                              //Debug.Log("<color=blue>blue:</color>" + Selection.gameObjects[j].name);
                              break;
                         }

                    }
     
               }
              
          }

     }
     void fns_ConditionsAndResult()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }
               
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                   
                         Selection.gameObjects[i].AddComponent<N_Name>();
                         Selection.gameObjects[i].AddComponent<N_state>();
                         Selection.gameObjects[i].AddComponent<N_HandleEvent_init>();
                         //Selection.gameObjects[i].AddComponent<N_LoadCondition>();
                         //Selection.gameObjects[i].AddComponent<N_LoadResultAction>(); 

               }

          }
     }
     void fns_removeID()
     {
          if (fns_checkSelect()==false)
          {
               return;
          }

          for (int i = 0; i < Selection.gameObjects.Length; i++)
          {
               AB_Name[] t_names = Selection.gameObjects[i].GetComponentsInChildren<AB_Name>();
               if (t_names!=null)
               {
                    for (int j = 0; j <t_names.Length ; j++)
                    {
                         t_names[j].m_ID = 0;
                         AB_HandleEvent t_event = t_names[j].gameObject.GetComponent<AB_HandleEvent>();
                         if (t_event!=null)
                         {
                              t_event.m_MachineName = E_MachineName.e_null;
                         }
                    }
               }
          }
     }
     bool fns_checkSelect()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return false;
               }
          }
          else
          {
               return false;
          }
          return true;
     }
     int m_ID;
     /// <summary>
     /// 查找ID
     /// </summary>
     void fns_findItemID()
     {
          if (fns_checkSelect() == false)
          {
               return;
          }
          List<GameObject> t_objects = new List<GameObject>();
          Debug.Log("<color=blue>select number = </color>" + Selection.gameObjects.Length);
     
          for (int i = 0; i < Selection.gameObjects.Length; i++)
          {
               AB_Name t_names = Selection.gameObjects[i].GetComponent<AB_Name>();
               if (t_names != null)
               {
                    if (m_ID == t_names.m_ID)
                    {
                         t_objects.Add(Selection.gameObjects[i]);
                         //Debug.Log("<color=blue></color>" + m_ID + "--->" + t_names.name);
                         //Selection.SetActiveObjectWithContext(Selection.gameObjects[i],);
                    }
               }
          }
          fns_select(t_objects.ToArray());
         
          t_objects = null;
     }
     //选中指定的物体
     void fns_select(GameObject[] _select)
     {
          if (_select!=null)
          {
               if (_select.Length==0)
               {
                    return;
               }
               Selection.objects = _select; 
          }
     }
     /// <summary>
     /// 全局查找匹配对象，然后选中
     /// </summary>
     void fns_findItemIDNoSelect()
     {
          AB_Name[] t_name= GameObject.FindObjectsOfType<AB_Name>();
          List<GameObject> t_select = new List<GameObject>();
          for (int i = 0; i < t_name.Length; i++)
          {
               if (t_name[i].m_ID==m_ID)
               {
                    t_select.Add(t_name[i].gameObject); 
               }
               //Debug.Log("<color=blue>blue:</color>" + t_name[i].gameObject.name);
               
          }
          fns_select(t_select.ToArray());
          t_select = null;
          t_name = null;
     }

     void fns_chechMeshUV()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length > 1 || Selection.gameObjects.Length == 0)
               {
                    return;
               }
               GameObject t_select = Selection.gameObjects[0];
               Mesh t_mesh = t_select.GetComponent<MeshFilter>().sharedMesh;
               if (t_mesh!=null)
               {
                    if (t_mesh.uv!=null)
                    {
                         Debug.Log("<color=blue>uv1</color>");
                    }
                    if (t_mesh.uv2 != null)
                    {
                         Debug.Log("<color=blue>uv2</color>");
                    } if (t_mesh.uv3 != null)
                    {
                         Debug.Log("<color=blue>uv3</color>");
                    }
               }
          }
     }
     void fns_removeAIstatic()
     {
          //Transform[] t_sceneobj = GameObject.FindObjectsOfType<Transform>();
          //for (int i = 0; i <t_sceneobj.Length; i++)
          //{
          //     if (t_sceneobj[i].gameObject.isStatic)
          //     {
          //          t_sceneobj[i].gameObject.isStatic = true;

          //     }
          //     else
          //     {
          //          t_sceneobj[i].gameObject.
          //     }
          //}
     }

     string m_nameOfOp = "";
     void fns_addOptimiz()
     {
          if (Selection.activeGameObject != null)
          {
               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    Transform[] t_obj = Selection.gameObjects[i].GetComponentsInChildren<Transform>();
                    for (int j = 0; j < t_obj.Length; j++)
                    {
                         AB_OpMesh t_last = t_obj[j].gameObject.GetComponent<AB_OpMesh>();
                         if (t_last!=null)
                         {
                              DestroyImmediate(t_last);
                         }
                         AB_OpMesh t_opmesh = t_obj[j].gameObject.AddComponent<N_OpMesh>();
                         t_opmesh.M_Name = m_nameOfOp;

                    }
               }
               //AB_OpMesh[] t_ = Selection.gameObjects[0].GetComponentsInChildren<AB_OpMesh>();
               //for (int i = 0; i < t_.Length; i++)
               //{
               //     DestroyImmediate(t_[i]);
               //}
          }
     }
     void fnp_removeOptimiz()
     {
          if (Selection.activeGameObject != null)
          {

               AB_OpMesh[] t_ = Selection.gameObjects[0].GetComponentsInChildren<AB_OpMesh>();
               for (int i = 0; i < t_.Length; i++)
               {
                    DestroyImmediate(t_[i]);
               }
          }
     }
     void fnp_showOptimiz()
     {
          if (Selection.activeGameObject != null)
          {

               AB_OpMesh[] t_ = Selection.gameObjects[0].GetComponentsInChildren<AB_OpMesh>();
               for (int i = 0; i < t_.Length; i++)
               {
                    t_[i].fn_hide(!t_[i].fn_hideState());
                    //DestroyImmediate(t_[i]);
               }
          }
     }
     /// <summary>
     /// 装表接电的电线设置添加组件
     /// </summary>
     void fns_TableWireSet()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }

               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {

                    MeshCollider t_mh=Selection.gameObjects[i].AddComponent<MeshCollider>();
                    t_mh.cookingOptions = MeshColliderCookingOptions.None;
                    t_mh = null;
                    Selection.gameObjects[i].AddComponent<N_Wire01>();
                    Selection.gameObjects[i].AddComponent<WireLightTrigger02>();
                    Selection.gameObjects[i].AddComponent<N_WireMat>();
                    Selection.gameObjects[i].AddComponent<N_LightOneObj_03>();
                    Selection.gameObjects[i].layer = 8;

               }

          }
     }
     void fns_TableSetPortName()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }

               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    string t_name = Selection.gameObjects[i].name;
                    int t_id = int.Parse(t_name);
                    AB_Name t_nameid = Selection.gameObjects[i].GetComponent<AB_Name>();
                    t_nameid.m_ID = t_id;
                    
                    //MeshCollider t_mh = Selection.gameObjects[i].AddComponent<MeshCollider>();
                    //t_mh.cookingOptions = MeshColliderCookingOptions.None;
                    //t_mh = null;
                    //Selection.gameObjects[i].AddComponent<N_Wire01>();
                    //Selection.gameObjects[i].AddComponent<WireLightTrigger02>();
                    //Selection.gameObjects[i].AddComponent<N_WireMat>();
                    //Selection.gameObjects[i].AddComponent<N_LightOneObj_03>();
                    //Selection.gameObjects[i].layer = 8;

               }

          }
     }
     protected void fnp_setUIScale()
     {
          float t_value=3.846153846153846f;
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length == 0)
               {
                    return;
               }

               for (int i = 0; i < Selection.gameObjects.Length; i++)
               {
                    RectTransform t_theRect = Selection.gameObjects[i].GetComponent<RectTransform>();
                    if (t_theRect!=null)
                    {
                         //t_theRect.rect.height /= 3.846153846153846f;
                         
                         Debug.Log("<color=blue>修改尺寸</color>");
     
                         //t_theRect.rect.Set(t_theRect.rect.x, t_theRect.rect.y, );
                         //t_theRect.rect.size = new Vector2(t_theRect.rect.width / t_value, t_theRect.rect.height / t_value);
                         //t_theRect.rect.width = new Vector2(t_theRect.rect.width / t_value, t_theRect.rect.height / t_value);
                    }

               }

          }
     }
     //Vector3 m_cameraPos=Vector3.zero;
     //Quaternion m_cameraRotate=Quaternion.identity;
     //void fnp_thescene()
     //{
     //     Camera[] t_cameras= UnityEditor.SceneView.GetAllSceneCameras();
     //     for (int i = 0; i < t_cameras.Length; i++)
     //     {
     //          //t_cameras[i].
               
     //          if (t_cameras[i].name=="SceneCamera")
     //          {
     //               m_cameraPos = t_cameras[i].transform.position;
     //               m_cameraRotate = t_cameras[i].transform.rotation;
     //               Debug.Log("<color=blue>camera name :</color>" + m_cameraPos + "|" + m_cameraRotate);
     //               //Debug.Log("<color=blue>fieldOfView:</color>" + t_cameras[i].);
     //          }
     //     }

     //}
     //void fnp_backView()
     //{
     //     Camera[] t_cameras = UnityEditor.SceneView.GetAllSceneCameras();
     //     for (int i = 0; i < t_cameras.Length; i++)
     //     {
     //          //UnityEditor.SceneView
     //          //Debug.Log("<color=blue>camera name :</color>" + t_cameras[i].name);
     //          if (t_cameras[i].name == "SceneCamera")
     //          {
     //               Debug.Log("<color=red>camera name :</color>" + t_cameras[i].name);
     //                 t_cameras[i].gameObject.transform.position=m_cameraPos;
     //                 t_cameras[i].transform.rotation=m_cameraRotate;
     //                 Debug.Log("<color=blue>camera name :</color>" +
     //                      t_cameras[i].gameObject.transform.position + "|" + 
     //                      t_cameras[i].transform.rotation);

     //                 Debug.Log("<color=red>fieldOfView:</color>" + t_cameras[i].fov);
     
     //                 //t_cameras[i].far = 1f;
     //                 //UnityEditor.SceneView.RepaintAll();
     //          }
     //     }

     //}
     
  
}
