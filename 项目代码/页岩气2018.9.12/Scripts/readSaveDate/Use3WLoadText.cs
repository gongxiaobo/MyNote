using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
namespace GasPowerGeneration
{
     public class Use3WLoadText : MonoBehaviour
     {
          private ArrayList m_alText = new ArrayList();
          // Use this for initialization
          void Start()
          {
               //m_alText.Add("gong");
               //m_alText.Add("gong xiao , bo ,");

               //Debug.Log("<color=blue>path:</color>"+Application.dataPath);

               //CText.fnCreateFile(Application.dataPath, "test", m_alText);
               //CText.fnReadText("testcsv");

               //
               //FieldInfo[] t_info = typeof(testName).GetFields(BindingFlags.Instance | BindingFlags.Public);
               //for (int i = 0; i < t_info.Length; i++)
               //{

               //     Debug.Log("<color=red>red:</color>" + t_info[i].ToString());

               //}
               FieldInfo[] t_info = typeof(testName).GetFields(
                    BindingFlags.Instance | BindingFlags.Public);

               //Debug.Log("<color=red>red:</color>" + t_info.Length);

               //Dictionary<>
               testName t_testname = Activator.CreateInstance<testName>();
               //t_testname.ID = "1";
               //t_testname.Content = "x";

               //t_member.
               //t_info.SetValue(t_testname,new string[2]{"1","lsdj"});
               //Debug.Log("<color=red>red:</color>" + t_testname.Content);


               CSVManager.fnReadTextToDic<testName>("testcsv", t_table);
               foreach (var item in t_table.Values)
               {

                    Debug.Log("<color=blue>blue:</color>" + item.ID + "," + item.Content);

               }
          }
          Dictionary<string, testName> t_table = new Dictionary<string, testName>();
          // Update is called once per frame
          //void Update()
          //{

          //}
     }

}