using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace GasPowerGeneration
{
     //using Assets.EventSystem;
     ///<summary>
     ///@ version 1.0 /2017.0216/ :用于读表专用,科目任务列表，机器按键列表
     ///@ author gong
     ///@ version 1.1 /2017.0228/ :修改了表的加载方式，fn_loadtable（）方法可以处理所以机器的表格和章节的表格
     ///@ author gong
     ///@ version 1.2 /2017.0307/ :获取章节的所有步骤：fn_getMachineData()
     ///@ author gong
     ///@ version 1.3 /2017.0421/ :加入汽车表的读取
     ///@ author gong
     ///</summary>
     public class S_LoadTable : GenericDontDestroy<S_LoadTable>
     {
          ////所有的章节表格集合
          //private Dictionary<string,Dictionary<string,Chapter_step>> m_Chapter_step=new Dictionary<string, Dictionary<string,Chapter_step>>();//章节步骤表数据 
          ////具体的机器表格集合
          //private Dictionary<string,Dictionary<string,ConcreteMachine>> m_ConcreteMachine=new Dictionary<string, Dictionary<string,ConcreteMachine>>();//具体一种机器


          ////选择场景的UI状态表格
          //private IDictionary<string,StudyChapterTable> m_studychaptertable;
          ////所有机器的名称表
          //private Dictionary<string,N_allMachine> m_allMachine = null;
          //public Dictionary<string,N_allMachine> M_allMachine{get{return m_allMachine;}}

          ////选择场景的Main_UI状态表格
          //private Dictionary<string,N_mainState> m_mainstate=null;
          //public Dictionary<string,N_mainState> M_mainstate{ get { return m_mainstate; } }
          ////所以汽车类型的表数据
          //private Dictionary<string,N_carName> m_cars = new Dictionary<string, N_carName> ();
          //加载过的表名
          public List<string> m_tableNames = new List<string>();//
          //是否所以表格加载完成
          private bool m_isLoadedAllTables = false;
          public bool M_isLoadedAllTables { get { return m_isLoadedAllTables; } set { m_isLoadedAllTables = value; } }
          //UI的表格信息
          private Dictionary<string, Dictionary<string, UILanguageTable>> m_UIDate = new Dictionary<string, Dictionary<string, UILanguageTable>>();
          /// <summary>
          /// 测试用
          /// </summary>
          public Dictionary<string, Dictionary<string, NameItemInfo>> m_nameinfo = new Dictionary<string, Dictionary<string, NameItemInfo>>();
          #region new tables
          //所有的表格名称，需要加载的表名称
          protected Dictionary<string, table_names> m_alltables = new Dictionary<string, table_names>();
          public Dictionary<string, table_names> M_alltables { get { return m_alltables; } }
          //声音名称表
          private Dictionary<string, sound_names_type> m_allsounds = new Dictionary<string, sound_names_type>();

          public Dictionary<string, sound_names_type> M_allsounds
          {
               get { return m_allsounds; }
          }
          //特殊声音的配置表格
          private Dictionary<string, special_name> m_specialsounds = new Dictionary<string, special_name>();

          public Dictionary<string, special_name> M_specialsounds
          {
               get { return m_specialsounds; }
          }
          //步骤开始结束的语音提示
          private Dictionary<string, normal_sound> m_normalsound = new Dictionary<string, normal_sound>();

          public Dictionary<string, normal_sound> M_normalsound
          {
               get { return m_normalsound; }
               //set { m_normalsound = value; }
          }
          /// <summary>
          /// 科目的初始化表格
          /// </summary>
          private Dictionary<string, Dictionary<string, subject_init>> m_subject_init =
               new Dictionary<string, Dictionary<string, subject_init>>();
          /// <summary>
          /// 科目的步骤表格
          /// </summary>
          private Dictionary<string, Dictionary<string, subject_step>> m_subject_step =
               new Dictionary<string, Dictionary<string, subject_step>>();
          /// <summary>
          /// 认知介绍的数据,
          /// </summary>
          private Dictionary<string, Dictionary<string, item_name>> m_item_name =
                   new Dictionary<string, Dictionary<string, item_name>>();
          /// <summary>
          /// 步骤的每一步的详情名称显示
          /// </summary>
          private Dictionary<string, Dictionary<string, N_connectDetail>> m_StepInforDetail =
               new Dictionary<string, Dictionary<string, N_connectDetail>>();
          /// <summary>
          /// 步骤的每一步的详情名称显示
          /// </summary>
          public Dictionary<string, Dictionary<string, N_connectDetail>> M_StepInforDetail
          {
               get { return m_StepInforDetail; }
               //set { m_StepInforDetail = value; }
          }
          
          /// <summary>
          /// cdp的分支编号名称
          /// </summary>
          private Dictionary<string, cdp_groupname> m_groupname = new Dictionary<string, cdp_groupname>();

          public Dictionary<string, cdp_groupname> M_groupname
          {
               get { return m_groupname; }
               //set { m_groupname = value; }
          }
          /// <summary>
          /// cdp的成员名称
          /// </summary>
          private Dictionary<string, cdp_item> m_cdpItem = new Dictionary<string, cdp_item>();

          public Dictionary<string, cdp_item> CdpItem
          {
               get { return m_cdpItem; }
               //set { m_cdpItem = value; }
          }
          //cdp项根据组分成
          private Dictionary<int, Dictionary<int, cdp_item>> m_cdpItems =
              new Dictionary<int, Dictionary<int, cdp_item>>();

          public Dictionary<int, Dictionary<int, cdp_item>> M_cdpItems
          {
               get { return m_cdpItems; }
               //set { m_cdpItems = value; }
          }
          private Dictionary<int, int> m_cdp_itemNum = new Dictionary<int, int>();

          public Dictionary<int, int> M_cdp_itemNum
          {
               get { return m_cdp_itemNum; }
               //set { m_cdp_itemNum = value; }
          }

          //登录ui各科目结构表
          private Dictionary<string, login_ui> m_loginui_dic = new Dictionary<string, login_ui>();
          public Dictionary<string, login_ui> M_loginui_dic
          {
               get { return m_loginui_dic; }
          }
          //整体机器介绍的读表信息
          private Dictionary<string, introduce> m_introduce = new Dictionary<string, introduce>();

          #endregion

          //	void Start(){
          //	
          //	}
          /// <summary>
          /// 根据表的名称加载表
          /// </summary>
          /// <param name="_tablename">Tablename.</param>
          public void fn_loadtable(string _tablename)
          {
               switch (_tablename)
               {
                    //case"mainstate"://选择场景读表
                    //     if (m_mainstate==null) {
                    //          m_mainstate = new Dictionary<string, N_mainState> ();
                    //          //CSVManager.LoadResource (_tablename, m_mainstate);
                    //          CSVManager.fnReadTextToDic(_tablename, m_mainstate);
                    //          m_tableNames.Add (_tablename);
                    //          //GlobalEventSystem<N_gloab_mainstate>.Raise (new N_gloab_mainstate (true));
                    //     }
                    //     break;
                    //case"chapterset01"://选择场景读表
                    //     if (m_studychaptertable==null) {
                    //          m_studychaptertable = new Dictionary<string, StudyChapterTable> ();
                    //          CSVManager.fnReadTextToDic(_tablename, m_studychaptertable);
                    //          m_tableNames.Add (_tablename);
                    //     }
                    //     break;
                    //case"machine"://读取所有机器的表单
                    //     if (m_allMachine==null) {
                    //          m_allMachine = new Dictionary<string, N_allMachine> ();
                    //          CSVManager.fnReadTextToDic(_tablename, m_allMachine);
                    //          m_tableNames.Add (_tablename);
                    //     }
                    //  break;normal_sound
                    case "table_names"://读取第一张表单           
                         CSVManager.fnReadTextToDic(_tablename, m_alltables);
                         break;
                    case "sound_names"://读取声音表单           
                         CSVManager.fnReadTextToDic(_tablename, m_allsounds);
                         break;
                    case "special_sound_ce"://读取特殊声音的表单        
                         CSVManager.fnReadTextToDic(_tablename, m_specialsounds);
                         break;
                    case "normal_sound"://步骤开始结束的语音提示    
                         CSVManager.fnReadTextToDic(_tablename, m_normalsound);
                         break;
                    case "CDP_groupname"://cdp 组名称    
                         CSVManager.fnReadTextToDic(_tablename, m_groupname);
                         break;
                    case "CDP_item"://cdp 的成员项
                         CSVManager.fnReadTextToDic(_tablename, m_cdpItem);
                         Invoke("fnp_rePackdate", 1.5f);
                         break;
                    case "introduce_table"://机器介绍的文字和配置表
                         CSVManager.fnReadTextToDic(_tablename, m_introduce);
                         Invoke("fnp_reLoadIntroduceTable", 1.5f);
                         break;
                    case "LoginUI":
                         CSVManager.fnReadTextToDic(_tablename, m_loginui_dic);
                         break;
                    default:
                         break;
               }
          }
          #region 把 CdpItem重新分组，方便调用
          /// <summary>
          /// 把 CdpItem重新分组，方便调用
          /// </summary>
          protected void fnp_rePackdate()
          {
               if (CdpItem == null)
               {
                    return;
               }
               if (CdpItem.Count == 0)
               {
                    return;
               }
               //int t_groupID = 0;
               //int t_memberID = 1;
               foreach (var item in CdpItem.Values)
               {

                    if (!m_cdpItems.ContainsKey(item.m_groupname))
                    {
                         m_cdpItems.Add(item.m_groupname, new Dictionary<int, cdp_item>());
                         fnp_finddate(item.m_groupname, item);
                         m_cdp_itemNum.Add(item.m_groupname, 1);
                    }
                    else
                    {
                         fnp_finddate(item.m_groupname, item);
                         m_cdp_itemNum[item.m_groupname]++;
                    }

               }
          }

          private void fnp_finddate(int t_groupID, cdp_item item)
          {
               if (!m_cdpItems[t_groupID].ContainsKey(item.m_member))
               {
                    m_cdpItems[t_groupID].Add(item.m_member, item);
               }
               else
               {
                    Debug.Log("<color=red>cdp 项中有重复的 ：</color>" + t_groupID);
               }
          }
          #endregion
          protected Dictionary<int, introduce> m_introduceMacID = new Dictionary<int, introduce>();
          #region 机器介绍的文字和配置表的重组
          protected void fnp_reLoadIntroduceTable()
          {
               foreach (var mac in m_introduce.Values)
               {
                    if (!m_introduceMacID.ContainsKey(mac.m_macID))
                    {
                         m_introduceMacID.Add(mac.m_macID, mac);
                    }
                    else { Debug.Log("<color=red>机器介绍表格中有相同的ID</color>"); }


               }
          }
          /// <summary>
          /// 获取机器介绍的一台机器的信息
          /// </summary>
          /// <param name="_macID"></param>
          /// <returns></returns>
          public introduce fn_getIntroduceInfo(int _macID)
          {
               if (m_introduceMacID.ContainsKey(_macID))
               {
                    return m_introduceMacID[_macID];
               }
               return null;
          }
          #endregion
          /// <summary>
          /// 读取机器和章节步骤的表格
          /// </summary>
          /// <param name="_tablename">表名称</param>
          /// <param name="_type">表的类型</param>
          public void fn_loadtable(string _tablename, string _type)
          {
               switch (_type)
               {
                    //case"machine"://具体机器的表格
                    //     if (!m_ConcreteMachine.ContainsKey(_tablename)) {
                    //          m_ConcreteMachine.Add(_tablename,new Dictionary<string, ConcreteMachine>());
                    //          CSVManager.fnReadTextToDic(_tablename, m_ConcreteMachine[_tablename]);
                    //          m_tableNames.Add (_tablename);
                    //     }
                    //     break;
                    //case"chapter"://具体章节的表格
                    //     if (!m_Chapter_step.ContainsKey(_tablename)) {
                    //          m_Chapter_step.Add(_tablename,new Dictionary<string, Chapter_step>());
                    //          CSVManager.fnReadTextToDic(_tablename, m_Chapter_step[_tablename]);
                    //          m_tableNames.Add (_tablename);
                    //     }
                    //     break;
                    //case"car"://具体汽车的表格

                    //     CSVManager.fnReadTextToDic(_tablename, m_cars);
                    //          m_tableNames.Add (_tablename);

                    //     break;
                    case "ui"://UI的表格
                         if (!m_UIDate.ContainsKey(_tablename))
                         {
                              m_UIDate.Add(_tablename, new Dictionary<string, UILanguageTable>());
                              CSVManager.fnReadTextToDic(_tablename, m_UIDate[_tablename]);
                              m_tableNames.Add(_tablename);
                         }
                         break;
                    case "name":
                         if (!m_nameinfo.ContainsKey(_tablename))
                         {
                              m_nameinfo.Add(_tablename, new Dictionary<string, NameItemInfo>());
                              CSVManager.fnReadTextToDic(_tablename, m_nameinfo[_tablename]);
                              m_tableNames.Add(_tablename);
                         }
                         break;
                    case "init":
                         if (!m_subject_init.ContainsKey(_tablename))
                         {
                              m_tableNames.Add(_tablename);
                              m_subject_init.Add(_tablename, new Dictionary<string, subject_init>());
                              CSVManager.fnReadTextToDic(_tablename, m_subject_init[_tablename]);
                         }
                         break;
                    case "step":
                         if (!m_subject_step.ContainsKey(_tablename))
                         {
                              m_tableNames.Add(_tablename);
                              m_subject_step.Add(_tablename, new Dictionary<string, subject_step>());
                              CSVManager.fnReadTextToDic(_tablename, m_subject_step[_tablename]);
                         }
                         break;
                    case "item":
                         if (!m_item_name.ContainsKey(_tablename))
                         {
                              m_tableNames.Add(_tablename);
                              m_item_name.Add(_tablename, new Dictionary<string, item_name>());
                              CSVManager.fnReadTextToDic(_tablename, m_item_name[_tablename]);
                         }
                         break;
                    case "stepinfo":
                         if (!m_StepInforDetail.ContainsKey(_tablename))
                         {
                              m_tableNames.Add(_tablename);
                              m_StepInforDetail.Add(_tablename, new Dictionary<string, N_connectDetail>());
                              CSVManager.fnReadTextToDic(_tablename, m_StepInforDetail[_tablename]);
                         }
                         break;
                    default:
                         break;
               }

          }

          /// <summary>
          /// 根据表名和ui键名获取ui文本集合
          /// </summary>
          /// <param name="tablename"></param>
          /// <param name="_uikey"></param>
          /// <returns></returns>
          public UILanguageTable fn_getUILanguage(string tablename, string _uikey)
          {
               if (m_UIDate.ContainsKey(tablename))
               {
                    if (m_UIDate[tablename].ContainsKey(_uikey))
                    {
                         return m_UIDate[tablename][_uikey];
                    }
               }
               return null;
          }
          /// <summary>
          /// 测试用方法 读取名称通用资源
          /// </summary>
          /// <param name="tablename"></param>
          /// <param name="namekey"></param>
          /// <returns></returns>
          public NameItemInfo fn_getnameiteminfo(string tablename, string namekey)
          {
               if (m_nameinfo.ContainsKey(tablename))
               {
                    if (m_nameinfo[tablename].ContainsKey(namekey))
                         return m_nameinfo[tablename][namekey];

               }
               return null;
          }
          /// <summary>
          /// 获取初始化配置表
          /// </summary>
          /// <param name="_tableName"></param>
          /// <returns></returns>
          public Dictionary<string, subject_init> fn_getSubInit(string _tableName)
          {
               if (m_subject_init.ContainsKey(_tableName))
               {
                    return m_subject_init[_tableName];
               }
               return null;

          }
          /// <summary>
          /// 获取步骤表
          /// </summary>
          /// <param name="_tableName"></param>
          /// <returns></returns>
          public Dictionary<string, subject_step> fn_getSubStep(string _tableName)
          {
               if (m_subject_step.ContainsKey(_tableName))
               {
                    return m_subject_step[_tableName];
               }
               return null;
          }
          /// <summary>
          /// 获取认知列表信息
          /// </summary>
          /// <param name="_tableName"></param>
          /// <param name="_id"></param>
          /// <returns></returns>
          public item_name fn_getItemName(string _tableName, int _id)
          {
               string t_ID = _id.ToString();
               if (m_item_name.ContainsKey(_tableName))
               {
                    if (m_item_name[_tableName].ContainsKey(t_ID))
                    {
                         return m_item_name[_tableName][t_ID];
                    }
               }
               return null;
          }

     }

}