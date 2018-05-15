using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace GasPowerGeneration
{
     public class UseTableMakeObj : EditorWindow
     {
          [MenuItem("MyTool/UseTableMakeObj")]
          static void Apply()
          {
               Rect wr = new Rect(0, 0, 200, 200);
               UseTableMakeObj window = (UseTableMakeObj)EditorWindow.GetWindowWithRect(typeof(UseTableMakeObj),
                    wr, true, "Tool V1.0");
               window.Show();


          }
          void OnGUI()
          {
               GUI.skin.settings.selectionColor = Color.red;
               GUI.skin.settings.cursorColor = Color.green;
               if (GUILayout.Button("读取表格"))
               {

                    fnp_readTable();
               }
               if (GUILayout.Button("清除表格信息"))
               {

                    fnp_removeDic();
               }
               if (GUILayout.Button("生成物体"))
               {

                    fnp_makeObj();
               }
          }
          //
          Dictionary<string, cdp_item> m_cdp = new Dictionary<string, cdp_item>();
          protected void fnp_readTable()
          {
               CSVManager.fnReadTextToDic("CDP_item", m_cdp);
               fnp_dubug();
          }
          protected void fnp_dubug()
          {
               foreach (var cdp in m_cdp.Values)
               {

                    Debug.Log("<color=blue>blue:</color>" + cdp.m_groupname);

               }
          }
          protected void fnp_removeDic()
          {
               m_cdp.Clear();
          }
          /// <summary>
          /// 生成cdp的控制项物体
          /// </summary>
          protected void fnp_makeObj()
          {
               GameObject t_all = GameObject.Find("CDP") ?? new GameObject("CDP");
               int t_groupID = 0;
               //int t_memberID = 1;
               foreach (var item in m_cdp.Values)
               {

                    if (item.m_groupname == t_groupID)
                    {
                         //GameObject t_menber = new GameObject(item.m_member.ToString());
                         //t_menber.transform.parent =
                         //     t_all.transform.FindFisrtChild(item.m_groupname.ToString());
                         Transform t_find = t_all.transform.FindFisrtChild(item.m_groupname.ToString());
                         //GameObject t_first = (t_find != null) ? t_find.gameObject : null;

                         Transform t_FindMember = t_find.transform.FindFisrtChild(item.m_member.ToString());
                         GameObject t_menber = (t_FindMember != null) ? t_FindMember.gameObject : null;
                         if (t_menber == null)
                         {//新的子物体
                              t_menber = new GameObject(item.m_member.ToString());
                              t_menber.transform.parent = t_find;
                         }
                         else
                         {

                         }
                         //添加值
                         fnp_SetValue(t_menber, item);
                    }
                    else
                    {
                         t_groupID = item.m_groupname;
                         Transform t_find = t_all.transform.FindFisrtChild(item.m_groupname.ToString());
                         GameObject t_first = (t_find != null) ? t_find.gameObject : null;
                         if (t_first == null)
                         {//第一次创建父节点
                              t_first = new GameObject(t_groupID.ToString());
                              if (t_first.transform.parent != t_all.transform)
                              {
                                   t_first.transform.parent = t_all.transform;
                              }
                         }
                         else
                         {

                         }

                         //
                         Transform t_FindMember = t_first.transform.FindFisrtChild(item.m_member.ToString());
                         GameObject t_menber = (t_FindMember != null) ? t_FindMember.gameObject : null;
                         if (t_menber == null)
                         {//新的子物体
                              t_menber = new GameObject(item.m_member.ToString());
                              t_menber.transform.parent = t_first.transform;

                         }
                         else
                         {

                         }
                         //添加值
                         fnp_SetValue(t_menber, item);
                    }
               }

          }
          //为每一项添加存储值类
          protected void fnp_SetValue(GameObject _obj, cdp_item _values)
          {
               if (_obj != null)
               {
                    AB_cdpValue t_cdp = _obj.transform.GetComponent<AB_cdpValue>();
                    if (t_cdp != null)
                    {
                         //t_cdp.fn_setValue(_values.m_type, _values.m_values);
                    }
                    else
                    {
                         t_cdp = _obj.AddComponent<N_cdpChangeValue>();
                    }
                    t_cdp.fn_setValue(_values.m_type, _values.m_values);
                    t_cdp.fn_setSpeed(_values.m_select1, _values.m_select2);
                    //
                    fnp_SetItemInit(_obj, _values);
               }
          }
          //添加消息处理类和控制类
          protected void fnp_SetItemInit(GameObject _obj, cdp_item _values)
          {
               if (_obj != null)
               {
                    AB_HandleEvent t_handleEvent = _obj.transform.GetComponent<AB_HandleEvent>();
                    if (t_handleEvent != null)
                    {
                    }
                    else
                    {
                         t_handleEvent = _obj.AddComponent<N_HandleEvent_init>();
                    }
                    t_handleEvent.m_MachineName = E_MachineName.e_machine_33;
                    AB_Name t_name = _obj.GetComponent<AB_Name>();
                    t_name.m_ID = _values.m_itemID;
                    AB_State t_state = _obj.GetComponent<AB_State>();
                    fnp_setState(_values, t_state);
                    I_Control t_control = _obj.GetComponent<I_Control>();
                    if (t_control == null)
                    {
                         _obj.AddComponent<N_cdpControll>();
                    }
               }
          }

          private static void fnp_setState(cdp_item _values, AB_State t_state)
          {
               if (_values.m_type == "para")
               {
                    t_state.m_ItemValueType = E_valueType.e_inter_floatvalue;
                    t_state.m_ItemType = E_ItemType.e_interactive;
               }
               else if (_values.m_type == "set")
               {
                    t_state.m_ItemValueType = E_valueType.e_inter_string;
                    t_state.m_ItemType = E_ItemType.e_interactive;
               }
          }


     }

}