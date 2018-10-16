using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0305/ :读取CSV从StreamingAssets文件中读取
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public static class S_ReadCSV<T>
     {


          /// <summary>
          /// 读取CSV
          /// </summary>
          /// <param name="_name">表名</param>
          /// <param name="_dic">集合名称</param>
          public static void fns_readCSV(string _name, IDictionary<string, T> _dic)
          {

               ToReadCSV(_name, _dic);

          }
          static void ToReadCSV(string _name, IDictionary<string, T> _dic)
          {

               //		yield return new WaitForEndOfFrame ();
               if (_name == "")
               {
                    return;
               }
               if (_dic != null)
               {
                    string t_txtName = _name + ".csv";
                    var tRead = new StreamReader(Application.dataPath + "/StreamingAssets/" + t_txtName);
                    var tFileContents = tRead.ReadToEnd();
                    string t_content = "";
                    if (tFileContents != null)
                    {
                         t_content = tFileContents.ToString();
                         //			Debug.Log ("<color=blue>文件类容：</color>" + "-->" + t_content);
                    }
                    tRead.Close();
                    tRead.Dispose();

                    //		Dictionary<string,N_mainState> m_table = new Dictionary<string, N_mainState> ();
                    CSVManager.Parse<T>(_name, t_content, _dic);
               }

          }

     }

}