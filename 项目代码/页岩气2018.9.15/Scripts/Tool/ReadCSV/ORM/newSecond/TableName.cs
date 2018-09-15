using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0216/ :统一加载所以表
     ///@ author gong
     ///@ version 1.1 /2017.0228/ :读取表中表，不需要把表名一个一个写到类型中了
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class TableName : GenericSingletonClass<TableName>
     {

          // Use this for initialization
          void Start()
          {
               if (S_LoadTable.Instance.M_isLoadedAllTables)
               {
                    return;
               }
               //		if (S_LoadTable.Instance.m_tableNames.Count<0) {
               m_tableName.Add("mainstate");
               m_tableName.Add("chapterset01");
               m_tableName.Add("machine");

               if (m_tableName.Count > 0)
               {//先加载选择场景的UI状态表格chapterset01,和包含所以机器名单的表machine

                    m_names = new string[m_tableName.Count];
                    m_tableName.CopyTo(m_names);
                    StartCoroutine("loadtable");
               }

               Debug.Log("<color=red>TableName start</color>" + "-->");
               //		}


          }
          /// <summary>
          /// 
          /// </summary>
          private void fnpp_read()
          {

          }
          private List<string> m_tableName = new List<string>();
          private WaitForSeconds m_wait = new WaitForSeconds(0.2f);
          private string[] m_names;
          /// <summary>
          /// 开始加载 m_tableName中的表
          /// </summary>
          IEnumerator loadtable()
          {
               int t_id = 0;
               while (t_id < m_names.Length)
               {
                    yield return m_wait;

                    //			Debug.Log ("<color=yellow>加载名称</color>" + "-->" + m_names [t_id]);
                    S_LoadTable.Instance.fn_loadtable(m_names[t_id]);
                    t_id++;
               }
               fn_loadNames();
          }

          private Dictionary<string, string> m_MachineNames = new Dictionary<string, string>();
          /// <summary>
          /// 找到machine 表中所有的项
          /// </summary>
          public void fn_loadNames()
          {
               //Dictionary<string,N_allMachine> t_allMachine = S_LoadTable.Instance.M_allMachine;
               //if (t_allMachine!=null) {//把机器表格中表的类型重新生成集合
               //     foreach (string item in t_allMachine.Keys) {
               //          m_MachineNames.Add (item,t_allMachine[item].m_type);
               //     }
               //}
               //t_allMachine = null;

               //StartCoroutine ("loadMachineTable");

          }

          /// <summary>
          /// 加载machine表格中的表
          /// </summary>
          /// <returns>The machine table.</returns>
          IEnumerator loadMachineTable()
          {
               foreach (string item in m_MachineNames.Keys)
               {
                    yield return m_wait;
                    //			Debug.Log ("<color=blue>表名：</color>" + "-->" + item+":"+m_MachineNames[item]);
                    S_LoadTable.Instance.fn_loadtable(item, m_MachineNames[item]);
               }
               yield return m_wait;
               S_LoadTable.Instance.M_isLoadedAllTables = true;//所以表格加载完成


          }
     }

}