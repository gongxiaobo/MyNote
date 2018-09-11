using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
namespace GasPowerGeneration
{

     //namespace GCode{
     /// <summary>
     /// 创建文本文件，读取，写入
     /// </summary>
     public static class CText
     {
          public static void fnReadText(string strname)
          {

               try
               {
                    var tRead = new StreamReader(Application.dataPath + "/" + strname + ".csv");

                    var tFileContents = tRead.ReadToEnd();
                    tRead.Close();
                    string[] tstrlist = tFileContents.Split(new[]
			{
				"\r\n"
			}, StringSplitOptions.RemoveEmptyEntries);

                    tRead.Dispose();
                    for (int i = 2; i < tstrlist.Length; i++)
                    {
                         Debug.Log("<color=red>coloum:</color>" + i.ToString());

                         string[] row = tstrlist[i].Split(',');
                         foreach (var item in row)
                         {
                              Debug.Log(item);
                         }
                    }



               }
               catch (Exception)
               {

                    throw;
               }
          }
          public static void fnReadTextToDic<T>(string strname, IDictionary<string, T> _dic)
          {

               try
               {
                    //读取文件
                    var tRead = new StreamReader(S_CSVPath.m_path + "/" + strname + ".csv");

                    var tFileContents = tRead.ReadToEnd();
                    tRead.Close();

                    CSVManager.Parse<T>(strname, tFileContents, _dic);
                    //string[] tstrlist = tFileContents.Split(new[]
                    //     {
                    //          "\r\n"
                    //     }, StringSplitOptions.RemoveEmptyEntries);

                    //tRead.Dispose();
                    ////解析T类型
                    //FieldInfo[] t_info = typeof(T).GetFields(
                    //     BindingFlags.Instance | BindingFlags.Public);

                    //if (_dic.Count>0)
                    //{
                    //     _dic.Clear(); 
                    //}

                    ////动态生成T类型实例
                    //for (int i = 2; i < tstrlist.Length; i++)
                    //{
                    //     Debug.Log("<color=red>coloum:</color>" + (i-1).ToString());

                    //     string[] row = tstrlist[i].Split(',');
                    //     if (row.Length>t_info.Length)
                    //     {

                    //          Debug.Log("<color=red>严重错误：出现列数过多的问题:</color>");
                    //          continue;

                    //     }

                    //     T t_instance = Activator.CreateInstance<T>();
                    //     //t_info.SetValue(t_instance,)
                    //     for (int j = 0; j < row.Length; j++)
                    //     {
                    //          Debug.Log(row[j]);

                    //     }

                    //}



               }
               catch (Exception)
               {

                    throw;
               }
          }
          //public IList<string> fn_tableToColoum(string _csvName)
          //{




          //     IList<string> txtLines = aTxtContent.Split(new[]
          //               {
          //                    "\r\n"
          //               },
          //               StringSplitOptions.RemoveEmptyEntries).ToList();
          //     if (txtLines.Count < 2)
          //     {
          //          Debug.Log(string.Format("资源文件 <{0}> 格式不正确"));
          //          return null;
          //     }
          //     return txtLines;
          //}

          /// <summary>
          /// 从Resources目录中加载文本文件
          /// </summary>
          /// <returns>返回Arraylist字符串</returns>
          /// <param name="name">文件名.</param>
          public static ArrayList fnReadFromRS(string name)
          {
               TextAsset tTextAsset = Resources.Load(name) as TextAsset;
               if (tTextAsset == null)
               {
                    return null;
               }
               ArrayList tArraylist = new ArrayList();
               string[] tstrlist = tTextAsset.ToString().Split('\n');
               if (tstrlist.Length > 0)
               {
                    foreach (string sr in tstrlist)
                    {
                         tArraylist.Add(sr);
                    }
                    return tArraylist;
               }
               else
               {
                    return null;
               }

          }
          public static void fnCreateFile(string path, string name, string info)
          {
               StreamWriter tswWriter;
               FileInfo tFileInfoe = new FileInfo(path + "//" + name);
               if (!tFileInfoe.Exists)
               {
                    tswWriter = tFileInfoe.CreateText();
               }
               else
               {
                    tswWriter = tFileInfoe.AppendText();
               }
               tswWriter.WriteLine(info);
               tswWriter.Close();
               tswWriter.Dispose();
          }
          public static void fnCreateFile(string path, string name, char[] info)
          {
               StreamWriter tswWriter;
               FileInfo tFileInfoe = new FileInfo(path + "//" + name);
               if (!tFileInfoe.Exists)
               {
                    tswWriter = tFileInfoe.CreateText();
               }
               else
               {

                    tswWriter = tFileInfoe.AppendText();

               }

               tswWriter.WriteLine(info);
               tswWriter.Close();
               tswWriter.Dispose();
          }
          /// <summary>
          /// 以arraylist写入string
          /// </summary>
          /// <param name="path">Path.</param>
          /// <param name="name">Name.</param>
          /// <param name="allist">要写入的类容.</param>
          public static void fnCreateFile(string path, string name, ArrayList allist)
          {
               StreamWriter tswWriter;
               FileInfo tFileInfoe = new FileInfo(path + "//" + name);
               if (!tFileInfoe.Exists)
               {
                    tswWriter = tFileInfoe.CreateText();

               }
               else
               {

                    tswWriter = tFileInfoe.AppendText();
                    //这里要对比已经存在的值		
               }
               foreach (string strString in allist)
               {
                    tswWriter.WriteLine(strString);
               }

               tswWriter.Close();
               tswWriter.Dispose();
          }
          //private bool ChangeDifferent(string textname){
          //	ArrayList m_tempArrayText=new ArrayList();
          //	m_tempArrayText=CText.fnLoadFile (Application.dataPath, textname);
          //
          //	foreach (string str in m_tempArrayText) {
          //
          //		Debug.Log (str);
          //	}
          //	return true;
          //}
          /// <summary>
          /// 从文件读取，
          /// </summary>
          /// <returns>字符串数组</returns>
          /// <param name="path">路径.</param>
          /// <param name="name">文件名.</param>
          public static ArrayList fnLoadFile(string path, string name)
          {

               StreamReader tsr = null;
               try { tsr = File.OpenText(path + "//" + name); }
               catch (Exception e)
               {
                    //			DebugManager.log (e);
                    Debug.Log(e);
                    return null;
               }
               string tstring;
               ArrayList arrlist = new ArrayList();
               while ((tstring = tsr.ReadLine()) != null)
               {
                    arrlist.Add(tstring);
               }
               tsr.Close();
               tsr.Dispose();
               return arrlist;
          }
          /// <summary>
          /// 根据路径删除文件
          /// </summary>
          /// <param name="path">Path.</param>
          /// <param name="name">Name.</param>
          public static void fnDeleteFile(string path, string name)
          {
               File.Delete(path + "//" + name);
          }

     }
     //}

}