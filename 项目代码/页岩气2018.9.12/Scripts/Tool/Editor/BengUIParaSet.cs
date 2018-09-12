using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GasPowerGeneration;
/// <summary>
/// 泵的操作界面的不同编号的泵的参数修改工具
/// 如果参数修改只需要修改泵1，其他使用工具进行修改
/// </summary>
public class BengUIParaSet : EditorWindow {

     [MenuItem("MyTool/BengUIParaSet")]
     static void init()
     {
          Rect wr = new Rect(0, 0, 200, 200);
          BengUIParaSet window = (BengUIParaSet)EditorWindow.GetWindowWithRect(typeof(BengUIParaSet),
               wr, true, "BengUIParaSet Tool V1.0");
          window.Show();


     }
     void OnGUI()
     {
          GUI.backgroundColor = Color.yellow;
          //GUI.skin.settings.selectionColor = Color.red;
          //GUI.skin.settings.cursorColor = Color.green;
          if (GUILayout.Button("泵参数检查"))
          {
               fnp_checkPara();
               //fnp_previewwire();
          }
          if (GUILayout.Button("泵参数同步"))
          {

               fnp_makeSamePara();
          }


     }
     protected void fnp_checkPara()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length <= 1 && Selection.gameObjects.Length > 2)
               {
                    return;
               }
               //Debug.Log("<color=blue>blue:</color>" + 
               //     Selection.gameObjects[0].transform.FindInChlid<Transform>().Count);
               List<Transform> bump1 = 
                    Selection.gameObjects[0].transform.FindInChlid<Transform>();
               List<Transform> bump2 = 
                    Selection.gameObjects[1].transform.FindInChlid<Transform>();
               for (int i = 1; i < bump1.Count; i++)
               {
                    AB_Name t_b1 = bump1[i].GetComponent<AB_Name>();
                    AB_Name t_b2 = bump2[i].GetComponent<AB_Name>();
                    if ((t_b1.m_ID+100)!=t_b2.m_ID)
                    {

                         Debug.Log("<color=red>id 不一样</color>" + bump1[i].name + ":" + bump2[i].name);
                         //continue;
     
                    }
                    AB_State t_s1 = bump1[i].GetComponent<AB_State>();
                    AB_State t_s2 = bump2[i].GetComponent<AB_State>();
                    if (t_s1.m_ItemValueType!=t_s2.m_ItemValueType)
                    {
                         Debug.Log("<color=red>AB_State 类型</color>" + bump1[i].name + ":" + bump2[i].name);
                         //continue;
                    }

                    N_bumpparam t_bp1 = bump1[i].GetComponent<N_bumpparam>();
                    N_bumpparam t_bp2 = bump2[i].GetComponent<N_bumpparam>();
                    if (t_bp1.param_type != t_bp2.param_type)
                    {
                         Debug.Log("<color=red>N_bumpparam 类型不同</color>" + bump1[i].name + ":" + bump2[i].name);
                         //continue;
                    }
                    else
                    {
                         if (t_bp1.param_type== bump_param_type.Param)
                         {
                              if (t_bp1.Range.x!=t_bp2.Range.x || t_bp1.Range.y!=t_bp2.Range.y)
                              {
                                   Debug.Log("<color=red>范围值 类型不同</color>" + bump1[i].name + ":" + bump2[i].name);
                              }
                         }
                    }


               }

          }
     }
     protected void fnp_makeSamePara()
     {
          if (Selection.activeGameObject != null)
          {
               if (Selection.gameObjects.Length <= 1 && Selection.gameObjects.Length>2)
               {
                    return;
               }
               //Debug.Log("<color=blue>blue:</color>" + 
               //     Selection.gameObjects[0].transform.FindInChlid<Transform>().Count);
               List<Transform> bump1 =
                    Selection.gameObjects[0].transform.FindInChlid<Transform>();
               List<Transform> bump2 =
                    Selection.gameObjects[1].transform.FindInChlid<Transform>();
               for (int i = 1; i < bump1.Count; i++)
               {
                    AB_Name t_b1 = bump1[i].GetComponent<AB_Name>();
                    AB_Name t_b2 = bump2[i].GetComponent<AB_Name>();
                    if ((t_b1.m_ID + 100) != t_b2.m_ID)
                    {
                         t_b2.m_ID = t_b1.m_ID + 100;
                         //Debug.Log("<color=red>id 不一样</color>" + bump1[i].name + ":" + bump2[i].name);
                         //continue;

                    }
                    AB_State t_s1 = bump1[i].GetComponent<AB_State>();
                    AB_State t_s2 = bump2[i].GetComponent<AB_State>();
                    if (t_s1.m_ItemValueType != t_s2.m_ItemValueType)
                    {
                         t_s2.m_ItemValueType = t_s1.m_ItemValueType;
                         //Debug.Log("<color=red>AB_State 类型</color>" + bump1[i].name + ":" + bump2[i].name);
                         //continue;
                    }

                    N_bumpparam t_bp1 = bump1[i].GetComponent<N_bumpparam>();
                    N_bumpparam t_bp2 = bump2[i].GetComponent<N_bumpparam>();
                    t_bp2.param_type = t_bp1.param_type;
                    if (t_bp1.param_type == bump_param_type.Param)
                    {
                        
                         t_bp2.Range = t_bp1.Range;
                    }
                   


               }

          }
     }
}
